using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
///<summary>
/// The <c> Ally </c> class which herit from Entity class.
/// Is used to create the player's team.
///</summary>
public class Ally : Entity
{
    ///<summary>
    /// Constructor of ally class which take in parameters all stat of entity.
    ///</summary>
    public Ally (int hpmax,  int atk, string name, int magicatk, int atkcost)
    {
        this.hpmax = hpmax;
        this.atk = atk;
        this.name = name;
        this.magicatk = magicatk;
        this.atkcost = atkcost;
        this.currenthp = hpmax;
    }
}
