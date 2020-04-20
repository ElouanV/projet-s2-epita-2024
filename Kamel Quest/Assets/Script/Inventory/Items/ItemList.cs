using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{

    public static Sprite healPotionSprite;
    // Usable(int ID, string name, string description, Sprite sprite)
    public static Usable healPotion = new Usable(0,"Heal Potion", "This potion will heal your unit", healPotionSprite);
    public static Sprite monsterRelicSprite;
    // Other(int ID, string name, string description, Sprite sprite)
    public static Other monsterRelic = new Other(1,"Monster relic", "You earn this by killing a monster, no one know how you can use it", monsterRelicSprite);
    public static Sprite firstSwordSprite;
    //Stuff (int ID, string name, string description,int boostStat, Sprite sprite)
    public static Stuff basicSword = new Stuff (2,"Basicsword","It's a basic sword, it up a little your damage, but you should try to find another powerfull sword", 1, firstSwordSprite);

    public Items[] itemlist = new Items[3] {healPotion,monsterRelic,basicSword};

    public Items[] GetItemsList()
    {
        return itemlist;
    }
 
}
