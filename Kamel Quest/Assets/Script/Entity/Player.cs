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
    public int[] inventoryID = new int[20];
    public int[] inventoryCount = new int[20];
    //public Ally[] team = new Ally[2]; ligne 45
    public static GameObject[] team = new GameObject[2];
    public GameObject[] _team;
    public int nbrOfKey = 0;

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
        _team = new GameObject[2];
    }

// FOR THE INVENTORY

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


// SAVE MANAGER
    ///<summary>
    ///
    /// 
    ///
    ///
    ///
    ///</summary>

    public GameObject swordslot;
    public GameObject shieldslot;
    public GameObject armorslot;
    public GameObject keyslot;

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this);
    }

    private void Start()
    {
        // Open while data's are loading to fix the invisible sprite bug
        Inventory_test myinventory = gameObject.GetComponent<Inventory_test>();
        myinventory.ShowOrHideInventory();
        Debug.Log("[Player] : [Start] : Player prefs load = "+ PlayerPrefs.GetInt("LoadData",0));
        if (PlayerPrefs.GetInt("LoadData",0) == 1) // If the player want to load a saved party
        {
            LoadPlayerData();
        }
        if (PlayerPrefs.GetInt("LoadData",0) == 2)
        {
            CreateNewParty();
        }
        // Hide inventory to start the game
        myinventory.ShowOrHideInventory();
        PlayerPrefs.DeleteKey("LoadData");
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
        LoadEquipment();
        //Load player's inventory
        inventoryCount = data.inventoryCountSlots;
        inventoryID  = data.inventoryIDSlots;
        LoadInventory();
        //Load player's team
            //TODO
        // Load quest datas
        for (int i = 0; i < data.finishedquest.Length; i++)
        {
            
        }
            //TODO LoadQuestProgress();
        //Load player's position
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        transform.position = position;
        Debug.Log("[LoadPlayerData] :Your party have been load successfully ! You can play !");
        Debug.Log("[LoadPlayerData] : Not all data have been loaded, this function have to be fixed");
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
        Debug.Log("[LoadInventory] : The inventory have been loaded");
    }

    private void LoadEquipment()
    {
        for (int i = 1; i < epeelvl; i++)
        {
            swordslot.GetComponent<EquipementSlot>().Upgrade();
        }
        for (int i = 1; i < bouclierlvl; i++)
        {
            shieldslot.GetComponent<EquipementSlot>().Upgrade();
        }
        for (int i = 1; i < armurelvl; i++)
        {
            armorslot.GetComponent<EquipementSlot>().Upgrade();
        }
        for (int i = 0; i < nbrOfKey; i++)
        {
            keyslot.GetComponent<KeySlot>().AddKey();
        }
        Debug.Log("[LoadEquipement] : The inventory have been loaded with equipments and keys");
    }

    private void LoadQuestProgress()
    {
        Debug.Log("[LoadQuestProgress] : Method isn't implemented yet.");
    }

    private void CreateNewParty()
    {
        Debug.Log("We are creating a new party, please wait");

        // Create player statitics
        argent = 0;
        lvl = 1;
        xp = 0;
        nbrOfKey = 0;
        //Load equipments levels
        armurelvl = 1;
        epeelvl = 1;
        bouclierlvl = 1;
        //Load player's inventory
        inventoryCount = new int[20];
        inventoryID  = new int[20];
        //Load player's team
            //TODO
        // Load quest datas
        //Load player's position
        Vector3 position;
        position.x = 0; // Position du tuto à set
        position.y = 0; // Position du tuto à set      
        position.z = 0;
        transform.position = position;
    }

}
