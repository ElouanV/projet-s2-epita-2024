using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
// Author : Elouan
///<summary>
/// The <c> Entity </c> class which class Ennemy, Player and Ally herit.
/// Is create all entity attribute.
///</summary>
public class Entity : MonoBehaviour
{
    public int[] LEVELUPXPNEEDED = new int[10];
    public int[] ATKPROGRESSION = new int[10];
    public int[] HPMAXPROGRESSION = new int[10];
    //liste d'effet
    public static string[] allEffectList = new[] {"Strengthening", "Regeneration", "Weakness", "Loot", "Damage", "Poison"};
    public List<string> effectList = new List<string>();
    
 
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
    public int item_id;
    
    //Pour le battle system
    public bool is_defence = false;
        
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

    void Start()
    {
        //Debug.Log(LEVELUPXPNEEDED.Length);
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
        Debug.Log("xp : " + xp + "xpearned : " + xpearned + "lvl : " + lvl );
        Debug.Log(LEVELUPXPNEEDED.Length);
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
    
    protected void LvlUp(int setxp) // appellée si l'entité augmente de niveau
    {
        atk += ATKPROGRESSION[lvl];
        hpmax += HPMAXPROGRESSION[lvl];
        GetXp(setxp);
        lvl += 1;
    }

    //effet possible et ajout dans la liste des effets


    public void AddEffect(string effect)
    {
        effectList.Append(effect);
    }

    public void RemoveEffect(string effect)
    {
        if (!effectList.Contains(effect))
        {
            return;
        }
        effectList.Remove(effect);
    }
    
    public bool loot()
    {
        return true;
    }
}
