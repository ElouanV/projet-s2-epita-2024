using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public readonly long[] LEVELUPXPNEEDED = {50, 125, 225, 350, 500, 700, 950, 1200, 1600};
    public readonly int[] ATKPROGRESSION = {3, 4, 6, 8, 11, 14, 18, 22, 27};
    public readonly int[] MAGICATKPROGRESSION = {3, 4, 6, 8, 11, 14, 18, 22, 27};
    public readonly long[] HPMAXPROGRESSION = {75, 150, 325, 600, 800, 1100, 1500, 1900, 2500};
    #region constructor
    // Attribut de la classe Entity
    public long hpmax;
    public long currenthp;
    public int atk;
    public string name;
    protected int magicatk;
    protected long atkcost;
    protected long xp;
    public int lvl;
    public bool isalive;
    
    //getter et setter
    public long Hpmax
    { 
        get => hpmax; 
    }
    public long CurrentHp
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
    public long Xp
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


        
    
    // Constructeur
    public Entity()
    {
        xp = 0;
        lvl = 1;
        isalive = true;
    }
    
    #endregion
    
    

    public void GetHurt(long damage) // inflige damage points de dégats à l'entité
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

    public void GetHeal(long heal) // soigne l'entité de heal points de vie
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

    protected void LvlUp(long setxp) // appelé si l'entité augmente de niveau
    {
        atk += ATKPROGRESSION[lvl];
        magicatk += MAGICATKPROGRESSION[lvl];
        hpmax += HPMAXPROGRESSION[lvl];
        xp = setxp;
        lvl += 1;
    }

    public void GetXp(long xpearned) // augmente l'xp de xpearned points
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
