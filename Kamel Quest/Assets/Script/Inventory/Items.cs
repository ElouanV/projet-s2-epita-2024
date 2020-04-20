using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemDescription;

    public Items (int ID, string name, string description)
    {
        this.itemID = ID;
        this.itemName = name;
        this.itemDescription = description;
    }

   /* public Items healPotion = new Items(1,"Heal Potion","This potion will heal one of your unite");
    public Items strenghtPotion = new Items(2,"Strenght Potion", "This potion will improve the strenght of one of your unite");
    public Items regenerationPotion = new Items(3,"Generation Potion", "This potion will heal your unite each turn in fight");
*/
}