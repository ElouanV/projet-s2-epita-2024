using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
///<summary>
/// The <c> Entity </c> class which class Ennemy, Player and Ally herit.
/// Is create all entity attribute.
///</summary>
public class Entity : MonoBehaviour
{
    public int[] LEVELUPXPNEEDED;
    public int[] ATKPROGRESSION;
    public int[] HPMAXPROGRESSION;
    // Attribut de la classe Entity
    public int hpmax;
    public int currenthp;
    public int atk;
    public string name;
    public int magicatk;
    public int atkcost;
    public int xp;
    public int lvl;
    public bool isalive;
    public GameObject[] drop_item = new GameObject[3];
    public int item_id;
        
    //getter et setter
    public int Hpmax
    { 
        get => hpmax; 
    }
    public int CurrentHp
    {
        get => currenthp;
    }
    public int Atk
    {
        get => atk;
    }
    public int MagicAtk
    {
        get => magicatk;
    }
    public int Xp
    {
        get => xp;
    }

    public int Lvl
    {
        get => lvl;
    }
    public bool Isalive
    {
        get => isalive;
    }
    public int Item_Id
    {
        get => item_id;
    }


        
    
    // Constructeur
    public Entity()
    {
        xp = 0;
        lvl = 1;
        isalive = true;
    }
    
    public void GetHurt(int damage) // inflige damage points de dégats à l'entité
    {
        if (currenthp > damage)
        {
            currenthp -= damage;
        }
        else
        {
            currenthp = 0;
            isalive = false;
        }
    }

    public void GetHeal(int heal) // soigne l'entité de heal points de vie
    {
        if (currenthp + heal <= hpmax)
        {
            currenthp += heal;
        }
        else
        {
            currenthp = hpmax;
        }
    }

    public void GetXp(int xpearned) // augmente l'xp de xpearned points
    {
        if (xp + xpearned >= LEVELUPXPNEEDED[lvl])
        {
            xp = xp + xpearned - LEVELUPXPNEEDED[lvl];
            LvlUp(xp);
        }
        else
        {
            xp += xpearned;
        }
    }
    
    protected void LvlUp(int setxp) // appelé si l'entité augmente de niveau
    {
        atk += ATKPROGRESSION[lvl];
        hpmax += HPMAXPROGRESSION[lvl];
        GetXp(setxp);
        lvl += 1;
    }
}
