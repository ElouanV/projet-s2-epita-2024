using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    public int[] inventoryID;
    public int[] inventoryCount;
    public Ally[] team;


    // To save settings
    public AudioMixer audioMixer;

    
    ///<summary>
    /// Constructor of player class which take in parameters all stat of player.
    ///</summary>
    public Player(int hpmax, int armure,  int atk, string name, int magicatk, int atkcost, int argent, int armurelvl, int epeelvl, int bouclierlvl, int casquelvl)
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
        // Inventory
        inventoryID = new int[20];
        inventoryCount = new int[20];
        // Player's ally
        this.team = new Ally[2];
    }



    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this, audioMixer);
    }
    public void LoadPlayerData()
    {
        //Get player data from binary save file
        PlayerData data = SaveSystem.LoadPlayer();
        // Load player statitics
        argent = data.playerMoney;
        lvl = data.playerLevel;
        xp = data.playerXP;
        //Load equipments levels
        armurelvl = data.playerEquipmentsLevel[0];
        epeelvl = data.playerEquipmentsLevel[1];
        bouclierlvl = data.playerEquipmentsLevel[2];
        //Load player's inventory
        inventoryCount = data.inventoryCountSlots;
        inventoryID  = data.inventoryIDSlots;
        //Load player's team
            //TODO
        //Load player's position
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        transform.position = position;
    }
}
