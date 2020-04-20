using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : Items
{
    public Usable(int ID, string name, string description, Sprite sprite)
    {
        this.itemName = name;
        this.itemID = ID;
        this.itemDescription = description;
        this.type = 0;
        this.sprite = sprite;
    }
}
