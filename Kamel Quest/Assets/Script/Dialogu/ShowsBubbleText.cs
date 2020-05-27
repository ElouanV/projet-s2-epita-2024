using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Julien
public class ShowsBubbleText : MonoBehaviour
{
    public GameObject Bubble;
	public bool is_trigger;
	// Display the bubble is the player is next to the PNG

	void Start()
	{
		if (is_trigger) OnTriggerEnter2D();
	}
    void OnTriggerEnter2D()
    {
		is_trigger = true;
		Bubble.SetActive(true);
    }

    // Close the bubble when the player goes away
	void OnTriggerExit2D()
    {
		is_trigger = false;
        Bubble.SetActive(false);
    }

	public void ExecuteTriggerExit2D()
	{
		OnTriggerExit2D();
	}
}
