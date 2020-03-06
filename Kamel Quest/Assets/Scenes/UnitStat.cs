using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    enum EntityType
    {
        PLAYER,
        ENEMY,
        PNJ
    }
    private List<Monster> team;
    private List<Item> inventory;
    private int lvl;
    public int Lvl => get;


    public Entity ()
    {
        this.team = new List<Monster>;
        inventory = new List<item>;
        this.lvl = lvl
    }
    public
}
