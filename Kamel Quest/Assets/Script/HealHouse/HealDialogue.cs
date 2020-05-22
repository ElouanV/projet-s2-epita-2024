using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDialogue : MonoBehaviour
{

    public Player  player;
    
	public bool is_trigger;
    
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
        foreach (Entity allier in Player.team)
        {
            allier.currenthp = allier.hpmax;
        }
    }
}
