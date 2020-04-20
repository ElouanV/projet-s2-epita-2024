using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public GameObject Shop;
	public bool is_trigger;
    public bool is_shop = false;

    void OnTriggerEnter2D()
    {
		is_trigger = true;
    }

	void OnTriggerExit2D()
    {
		is_trigger = false;
    }
    void Update()
    {
        if (is_trigger && Input.GetKeyUp("y"))
        {
            is_shop = true;
        }
    }
}
