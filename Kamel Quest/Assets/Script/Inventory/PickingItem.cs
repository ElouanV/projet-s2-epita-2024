using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingItem : MonoBehaviour
{
    public GameObject Player;
    public Sprite healPotionSprite; // temp 
    
    void OnTriggerEnter2D()
    {
        Items item = transform.GetComponent<Items>();
        Player.GetComponent<Inventory_test>().AddToInventory(item.itemID, item.itemName, 1, item.itemDescription, healPotionSprite);
        Destroy(gameObject);
    }
}
