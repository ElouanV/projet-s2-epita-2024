using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Julien
public class ShowsBubbleText : MonoBehaviour
{
    public GameObject Bubble;
	public bool is_trigger;

	/// <summary>
    /// Cette fonction permet d'afficher la bulle de text d'un pnj si on apparait dans sa boxe collider
    /// </summary>
	void Start()
	{
		if (is_trigger) OnTriggerEnter2D();
	}

	/// <summary>
    /// Cette fonction permet d'afficher la bulle de text d'un pnj si on rentre dans sa boxe collider
    /// </summary>
    void OnTriggerEnter2D()
    {
		is_trigger = true;
		Bubble.SetActive(true);
    }

    /// <summary>
    /// Cette fonction permet d'effacer la bulle de text d'un pnj si on sort dans sa boxe collider
    /// </summary>
	void OnTriggerExit2D()
    {
		is_trigger = false;
        Bubble.SetActive(false);
    }

	/// <summary>
    /// Cette fonction permet de simuler une entrer dans le box collider
    /// </summary>
	public void ExecuteTriggerExit2D()
	{
		OnTriggerExit2D();
	}
}
