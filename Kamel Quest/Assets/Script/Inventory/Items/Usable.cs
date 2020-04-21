using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Here is the constructor of Usable items
///<remaks>
/// before, there was a function Use() which can Use an item and apply effect on player, heal an unit for exmple of heal potion, but it generate a compilation error when i try to pass the Item class to scriptable object to fix probleme of ItemListe
///</remarks>
/// </summary>
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
