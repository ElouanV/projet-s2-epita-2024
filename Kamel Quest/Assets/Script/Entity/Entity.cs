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
    private long hpmax;
    public long currenthp;
    private int atk;
    private string name;
    private int magicatk;
    private long atkcost;
    private long xp;
    private int lvl;
    private bool isalive;
    
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
    public Entity(long hpmax, int atk, string name, int magicatk, int atkcost)
    {
        this.hpmax = hpmax;
        this.currenthp = hpmax;
        this.atk = atk;
        this.name = name;
        this.magicatk = magicatk;
        this.xp = 0;
        this.lvl = 1;
        this.isalive = true;
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

    private void LvlUp(long setxp) // appelé si l'entité augmente de niveau
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
