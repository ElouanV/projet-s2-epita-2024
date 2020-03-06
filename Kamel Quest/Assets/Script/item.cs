using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    enum ItelType
    {
        NONE,
        HEALTH_POTION,
        RESURECTION_POTION,
        ANTIDOTE,
        ANTIPARA
    }

    private ItemType type;
    private int ItemCount;

    public Item(ItemType type, int count)
    {
            this.type = type;
            this.ItemCount = count;
    }


    public void Add (int toadd)
    {
        Itemcount += toadd; // no stack limit
    }

    public bool Remove (int toremove)
    {
        if (Itemcount >= toremove)
        {
            ItemCount -= toremove;
            return true;
        }
        else // choose if then 'toremove' > Itemcount, should we set ItemCount at 0 or should we return false/ an error ? 
        {
            return false;
        }
    }
}
