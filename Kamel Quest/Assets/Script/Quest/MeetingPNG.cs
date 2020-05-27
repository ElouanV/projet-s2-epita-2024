using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Authors : Julien
public class MeetingPNG : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_active;
    public GameObject questgiver;
    
    void OnTriggerEnter2D()
    {
        if (!is_active) transform.GetComponent<ShowsBubbleText>().ExecuteTriggerExit2D();
    }
}
