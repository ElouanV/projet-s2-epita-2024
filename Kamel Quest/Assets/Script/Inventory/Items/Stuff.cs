using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Here is the constructor of Stuff items
///<remaks>
/// before, there was functions to Upgrade stuff and apply bonus on player but it generate a compilation error when i try to pass the Item class to scriptable object to fix probleme of ItemListe
///</remarks>
/// </summary>
public class Stuff : Items
{
    public int[] upgradeCost = new int[3] {15,50,150};
    public int[] upgradeValue = new int[3] {1,3,10};
    public int lvl;
    public int boostStat;

    public Stuff (int ID, string name, string description,int boostStat, Sprite sprite)
    {
        this.lvl = 1;
        this.boostStat = boostStat;
        this.itemID = ID;
        this.itemName = name;
        this.itemDescription = description;
        this.type = 1;
        this.sprite = sprite;
    }
    

}
