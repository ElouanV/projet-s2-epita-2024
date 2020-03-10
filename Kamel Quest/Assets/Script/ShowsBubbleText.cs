using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowsBubbleText : MonoBehaviour
{
    public GameObject Bubble;
	public bool is_trigger;
    
    void OnTriggerEnter2D()
    {
		is_trigger = true;
		Bubble.SetActive(true);
    }

	void OnTriggerExit2D()
    {
		is_trigger = false;
        Bubble.SetActive(false);
    }
}
