﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingPNG : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_active;
    public GameObject questgiver;
    
    void OnTriggerEnter2D()
    {
        Debug.Log("[MeetingPNG] OnTriggerEnter2D: The target have been trigger.");
        if (is_active) questgiver.GetComponent<Quest>().CompletedQuest();
    }
}
