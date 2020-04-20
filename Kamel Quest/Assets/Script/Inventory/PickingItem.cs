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
    public bool is_active;

    
    void OnTriggerEnter2D()
    {
        Items item = transform.GetComponent<Items>();
        Destroy(gameObject);
        Player.GetComponent<Inventory_test>().AddToInventory(item.itemID, item.itemName, 1, item.itemDescription, healPotionSprite);
        if (quest) questgiver.GetComponent<Quest>().CompletedQuest();
    }
}
