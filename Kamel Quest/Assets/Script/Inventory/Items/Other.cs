using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
/// <summary>
/// Here is the constructor of Other items
/// </summary>
public class Other : Items
{
    
    public Other(int ID, string name, string description, Sprite sprite)
    {
        this.itemName = name;
        this.itemID = ID;
        this.itemDescription = description;
        this.type = 0;
        this.sprite = sprite;
    }
}
