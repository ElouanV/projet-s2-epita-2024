using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Authors : Julien
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
        Debug.Log("[PickingItem] OnTriggerEnter2D: The item have been picked.");
        if (quest) questgiver.GetComponent<Quest>().CompletedQuest();
        else Player.GetComponent<Inventory_test>().AddToInventory(item.itemID, 1);
    }
}
