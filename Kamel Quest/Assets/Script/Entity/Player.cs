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
    public int[] inventoryID = new int[20];
    public int[] inventoryCount = new int[20];
    public Ally[] team = new Ally[2];



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















// SAVE MANAGER

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this, audioMixer);
    }
    public void LoadPlayerData()
    {
        Debug.Log("We are downloading your party, please wait");
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
        LoadInventory();
        //Load player's team
            //TODO
        //Load player's position
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        transform.position = position;
        Debug.Log("Your party have been load successfully ! You can play !");
    }

    private void LoadInventory()
    {
        Inventory_test myinventory = gameObject.GetComponent<Inventory_test>();
        for (int i = 0; i < 20; i++)
        {
            if (inventoryID[i] > 0)
            {
                myinventory.AddToInventory(inventoryID[i], inventoryCount[i]);
            }
        }
    }


    public bool isInInventory(int ID, int needed)
    {

        int total = 0;
        for (int i = 0; i < 20; i++)
        {
            if (inventoryID[i] == ID)
            {
                total += inventoryID[i];
            }
        }
        if (total >= needed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int HowMuchInInventory(int ID)
    {
        int total = 0;
        for (int i = 0; i<20; i++)
        {
            if (inventoryID[i] == ID)
            {
                total += inventoryID[i];
            }
        }
        return total;
    }

    void Start()
    {
        Debug.Log("[Player] : [Start] : Player prefs load = "+ PlayerPrefs.GetInt("Load",0));
        if (PlayerPrefs.GetInt("Load",0) == 1)
        {
            
            LoadPlayerData();
        }
        PlayerPrefs.DeleteKey("Load");
    }
}
