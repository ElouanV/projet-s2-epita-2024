using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingItem : MonoBehaviour
{
    public GameObject Player;
    public Sprite healPotionSprite; // temp 
    public bool quest;
    
    // Only for the quest
    public GameObject questgiver;


    void OnTriggerEnter2D()
    {
        Items item = transform.GetComponent<Items>();
        Destroy(gameObject);
        Player.GetComponent<Inventory_test>().AddToInventory(item.itemID, 1);
        if (quest) questgiver.GetComponent<Quest>().CompletedQuest();
    }
}
