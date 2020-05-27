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
    public static string[] allEffectList = new[] {"Strengthening", "Regeneration", "Weakness", "Loot", "Damage", "Poison","Heal"};
    public List<(string,int)> effectList = new List<(string,int)>();
 
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
    
    // Constructeur
    public Entity()
    {
        xp = 0;
        lvl = 1;
        isalive = true;
    }
    
    ///<summary>
    /// <param Name = "damage"> corresponding to the amount of damage to dealt to this entity </param>
    /// <remarks> health point can not be under 0 </remarks>
    ///</summary>
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


    ///<summary> Heal the entity
    ///<param Name = "heal"> Corresponding to the amount of healthh point to heal</param>
    ///<remarks> The health point can not be over the maximum of health point </remaks>
    ///</summary>
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

    ///<summary> Give xp to thhis entity
    ///<param Name = "xp"> Corresponding to the amount of experience points to give to the entity</param>
    ///<remarks> If xp is over the limit of a the xp needed to level up, the entity gain a level </remaks>
    ///</summary>
    public void GetXp(int xpearned)
    {
        xp += xpearned;
        while (xp > LEVELUPXPNEEDED[lvl -1]&& lvl <10)
        {
            lvl +=1;
        }
    }

    // ajout dans la liste des effets et execute les effets dit "passif"


    public void AddEffect((string, int) effect)
    {
        effectList.Append(effect);
		switch(effect.Item1)
		{
			case "Strengthening":
                break;
			case "Weakness":
                break;
			case "Loot":
                break;
		}
    }
	// retire des effets et reinitialiser les effet "passif"

    public void RemoveEffect(string effect, Entity unit)
    {
        int i = 0;
		bool find = false;

		while (i < unit.effectList.Count && !find)
		{
			find = unit.effectList[i].Item1 == effect;
			if (find) 
			{
				unit.effectList.Remove(effectList[i]);
			    //switch(CrrtEffect.Item1)
                switch (effect)
			    {
			    	case "Weakness":

			    		break;
			    	case "Strengthening":

			    		break;
				}  
			}
			i++;
		}
	}
    
    public bool Loot()
    {
        return true;
    }
    
}
