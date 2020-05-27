using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDialogue : MonoBehaviour
{

    public Player  player;
	public bool is_trigger;
    
    /// <summary>
    /// Soinge la totalité de l'équipe du palyer
    /// </summary>
    /// <remarks>
    /// <para>Déclenche si dialogues </para>
    /// </remarks>
    
    void Update()
    {
        if (is_trigger && Input.GetKeyUp(KeyCode.Space))
        {
            HealTeam();
        }
    }


	// Display the bubble is the player is next to the PNG
    void OnTriggerEnter2D()
    {
		is_trigger = true;
		Debug.Log("[HealDialogue] OnTriggerEnter2D: HealTeam ");
    }

    // Close the bubble when the player goes away
	void OnTriggerExit2D()
    {
		is_trigger = false;
    }

    void HealTeam()
    {
        foreach (GameObject allier in player._team)
        {
            if (allier != null)
            {
                allier.GetComponent<Entity>().currenthp = allier.GetComponent<Entity>().hpmax;
            }
        }
    }
}
