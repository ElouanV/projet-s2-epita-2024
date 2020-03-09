using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{
    public GameObject Bubble;
    public bool isTrigger;

    void OnTriggerEnter2D()
    {
        isTrigger = true;
        Bubble.SetActive(isTrigger);
    }

    void OnTriggerExit2D()
    {
        isTrigger = false;
        Bubble.SetActive(isTrigger);
    }
}

