using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
///<summary>
/// The <c> Ennemy </c> class which herit from Entity class.
/// Is used to create ennemy team.
///</summary>
public class Ennemy : Entity
{
    ///<summary>
    /// Constructor of ennemy class which take in parameters all stat of entity
    ///</summary>
    public Ennemy(long hpmax,  int atk, string name, int magicatk, int atkcost)
    {
        this.hpmax = hpmax;
        this.atk = atk;
        this.name = name;
        this.magicatk = magicatk;
        this.atkcost = atkcost;
        this.currenthp = hpmax;
    }

}
