﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingItem : MonoBehaviour
{
    public GameObject Player;
    public bool quest;
    
    // Only for the quest
    public GameObject questgiver;


    void OnTriggerEnter2D()
    {
        Items item = transform.GetComponent<Items>();
        Destroy(gameObject);
        Player.GetComponent<Inventory_test>().AddToInventory(item.itemID, 1);
        Debug.Log("[PickingItem] OnTriggerEnter2D: The item have been destroyed from the map and add to your inventory.");
        if (quest) questgiver.GetComponent<Quest>().CompletedQuest();
    }
}
