using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Julien
public class ShowsBubbleText : MonoBehaviour
{
    public GameObject Bubble;
	public bool is_trigger;
    
	// Display the bubble is the player is next to the PNG
    void OnTriggerEnter2D()
    {
		is_trigger = true;
		Bubble.SetActive(true);
		Debug.Log("[ShowsBubbleText] OnTriggerEnter2D: The bubble is now active.");

    }

    // Close the bubble when the player goes away
	void OnTriggerExit2D()
    {
		is_trigger = false;
        Bubble.SetActive(false);
        Debug.Log("[ShowsBubbleText] OnTriggerExit2D: The bubble is now inactive.");
    }

	public void ExecuteTriggerExit2D()
	{
		OnTriggerExit2D();
	}
}
