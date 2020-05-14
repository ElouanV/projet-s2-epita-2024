using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
///<summary>
/// The <c> Player </c> class which herit from Entity class.
/// Is used only for player 
///</summary>
public class Player : Entity
{
    public int argent;
    public int armurelvl;
    public int epeelvl;
    public int bouclierlvl;
    public int casquelvl;
    public int armure;

    ///<summary>
    /// Constructor of player class which take in parameters all stat of player.
    ///</summary>
    public Player(long hpmax, int armure,  int atk, string name, int magicatk, int atkcost, int argent, int armurelvl, int epeelvl, int bouclierlvl, int casquelvl)
    {
        this.argent = argent;
        this.currenthp = hpmax;
        this.atkcost = atkcost;
        this.magicatk = magicatk;
        this.hpmax = hpmax;
        this.atk = atk;
        this.name = name;
        this.armure = armure;
        //Equipement Automatiquement à 0
        this.armurelvl = armurelvl;
        this.epeelvl = epeelvl;
        this.bouclierlvl = bouclierlvl;
        this.casquelvl = casquelvl;
    }
}
