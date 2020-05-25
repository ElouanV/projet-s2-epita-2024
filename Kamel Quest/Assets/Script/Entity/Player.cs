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
    public int[] armureboost = new int[3];
    public int epeelvl;
    public int[] epeeboost = new int[3];
    public int bouclierlvl;
    public int[] bouclierboost = new int[3];
    public int casquelvl;
    public int armure;
    public int[] inventoryID = new int[20];
    public int[] inventoryCount = new int[20];
    //public Ally[] team = new Ally[2]; ligne 45
    public static GameObject[] team = new GameObject[2];
    public GameObject[] _team;
    public int nbrOfKey = 0;
    public bool[] beatenMonster;


    ///<summary>
    /// Constructor of player class which take in parameters all stat of player.
    ///</summary>
    public Player(int hpmax, int armure,  int atk, string name, int magicatk, int atkcost, int argent, int armurelvl, int epeelvl, int bouclierlvl, int casquelvl)
    {
        LEVELUPXPNEEDED = new int[10];
        ATKPROGRESSION = new int[10];
        HPMAXPROGRESSION = new int[10];
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

    public void AddToInventory(int ID)
    {
        bool added = false;
        for (int i = 0; i < 20; i++)
        {
            if (inventoryID[i] == ID && inventoryCount[i] <64)
            {
                inventoryCount[i] +=1;
                added = true;
            }
        }
        if (!added)
        {
            for (int i = 0; i < 20; i++)
            {
                if (inventoryID[i] == 0)
                {
                    inventoryID[i] = ID;
                    inventoryCount[i] = 1;
                }
            }
        }
    }
    public void RemoveFromInventory(int ID)
    {
        bool deleted = false;
        int i = 19;
        while (i>= 0 && !deleted)
        {
            if (inventoryID[i] == ID)
            {
                if (inventoryCount[i]>1)
                {
                    inventoryCount[i] -=1;
                }
                else
                {
                    inventoryCount[i] = 0;
                    inventoryID[i] = 0;
                }
                deleted = true;
            }
            i +=1;
        }
    }


// SAVE MANAGER
    ///<summary>
    ///
    /// 
    ///
    ///
    ///
    ///</summary>
    [Header ("For save")]
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
        
        Debug.Log("[Player] : [Start] : Player prefs load = "+ PlayerPrefs.GetInt("LoadData",0));
        if (PlayerPrefs.GetInt("LoadData",0) == 1) // If the player want to load a saved party
        {
            // Open while data's are loading to fix the invisible sprite bug
            Inventory_test myinventory = gameObject.GetComponent<Inventory_test>();
            myinventory.ShowOrHideInventory();
            LoadPlayerData();
            // Hide inventory to start the game
            myinventory.ShowOrHideInventory();
        }
        if (PlayerPrefs.GetInt("LoadData",0) == 2) //  If the player want to start a new game
        {
            // Open while data's are loading to fix the invisible sprite bug
            Inventory_test myinventory = gameObject.GetComponent<Inventory_test>();
            myinventory.ShowOrHideInventory();
            CreateNewParty();
            // Hide inventory to start the game
            myinventory.ShowOrHideInventory();
        }
        if (PlayerPrefs.GetInt("LoadData",0) == 3) // If the player start a battle
        {
            LoadPlayerForBattle();
        }   
        
        PlayerPrefs.DeleteKey("LoadData");
    }

    public void LoadPlayerData()
    {
        Debug.Log("We are downloading your party, please wait");
        //Get player data from binary save file
        PlayerData data = SaveSystem.LoadPlayer();

        // PLAYER
        argent = data.playerMoney;
        nbrOfKey = data.playerKey;
        int playerxp = data.playerXP;
        GetXp(playerxp);

        //EQUIPMENTS
        armurelvl = data.playerEquipmentsLevel[0];
        epeelvl = data.playerEquipmentsLevel[1];
        bouclierlvl = data.playerEquipmentsLevel[2];
        LoadEquipment();

        //INVENTORY
        inventoryCount = data.inventoryCountSlots;
        inventoryID  = data.inventoryIDSlots;
        LoadInventory();
        //TEAM
        Entity ally1 = _team[0].GetComponent<Entity>();
        Entity ally2 = _team[1].GetComponent<Entity>();
        ally1.GetXp(playerxp);
        ally2.GetXp(playerxp);
        LoadEquipementTeam(ally1, ally2, lvl);
        ally1.currenthp = data.playerTeamHp[0];
        ally2.currenthp = data.playerTeamHp[1];
        
        
        // QUEST 
        Progression progression = transform.GetComponent<Progression>();
        Debug.Log("[LoadingData] : Appel de LoadQuestProgress");
        LoadQuestProgress(data.questfinish);
        Debug.Log("[LoadingData] : Appel de LoadQuestProgressAnnex");
        LoadQuestProgressAnnex(data.finishedquestannex, progression);
        
        //POSITION
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        transform.position = position;

        //CAMERA
        Vector3 cameraposition;
        cameraposition.x = data.playerCameraPosition[0];
        cameraposition.y = data.playerCameraPosition[1];
        cameraposition.z = data.playerCameraPosition[2];
        GameObject.FindWithTag("MainCamera").transform.position = cameraposition;

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

    private void LoadQuestProgress(int lastquest)
    {
        Debug.Log("[LoadQuestProgress] : Method is running");
        Progression progression = transform.GetComponent<Progression>();
        progression.CurrentQuestGetSet = progression.Prog[0];
        Debug.Log("[NextQuest] : Current :" + progression.CurrentQuestGetSet);
        for (int i = 0; i < lastquest; i++)
        {
            Debug.Log("[LoadingQuestProgress] : Appel de NexQuests a l'indice " + i);
            progression.NextQuest();
            Debug.Log("[LoadQuestProgress] : NextQuest a finis de tourner");
        }
        Debug.Log("[LoadQuestProgress] : Method is finishing");
    }

    private void LoadQuestProgressAnnex(bool[] questprogress, Progression progression)
    {
        for (int i = 0; i < questprogress.Length; i++)
        {
            progression.UpdateAnexCompleted(progression.ProgAnex[i], i);
        }
    }

    private void LoadEquipementTeam(Entity ally1, Entity ally2, int lvl)
    {
        int atkboost = epeeboost[epeelvl-1];
        int hpboost = armureboost[armurelvl-1];
        ally1.atk += atkboost;
        ally2.atk += atkboost;
        ally1.hpmax += hpboost;
        ally1.hpmax += hpboost;
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
        position.x = -36; // Position du tuto à set
        position.y = -27; // Position du tuto à set      
        position.z = 0;
        transform.position = position;
    }

    private void LoadPlayerForBattle()
    {
        Debug.Log("We are downloading your party, please wait");
        //Get player data from binary save file
        PlayerData data = SaveSystem.LoadPlayer();

        // PLAYER
        argent = data.playerMoney;
        nbrOfKey = data.playerKey;
        int playerxp = data.playerXP;
        GetXp(playerxp);

        //EQUIPMENTS
        armurelvl = data.playerEquipmentsLevel[0];
        epeelvl = data.playerEquipmentsLevel[1];
        bouclierlvl = data.playerEquipmentsLevel[2];

        //INVENTORY
        inventoryCount = data.inventoryCountSlots;
        inventoryID  = data.inventoryIDSlots;
        //TEAM
        Entity ally1 = _team[0].GetComponent<Entity>();
        Entity ally2 = _team[1].GetComponent<Entity>();
        ally1.GetXp(playerxp);
        ally2.GetXp(playerxp);
        LoadEquipementTeam(ally1, ally2, lvl);
        ally1.currenthp = data.playerTeamHp[0];
        ally2.currenthp = data.playerTeamHp[1];
        
        
        // QUEST 
        Progression progression = transform.GetComponent<Progression>();
        progression.CurrentGetSet = data.questfinish;
        progression.AnnexCompleted = data.finishedquestannex;
        
        //POSITION
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        transform.position = position;

        //CAMERA
        Vector3 cameraposition;
        cameraposition.x = data.playerCameraPosition[0];
        cameraposition.y = data.playerCameraPosition[1];
        cameraposition.z = data.playerCameraPosition[2];
        GameObject.FindWithTag("MainCamera").transform.position = cameraposition;

        Debug.Log("[LoadPlayerData] :Your party have been load successfully ! You can play !");
        Debug.Log("[LoadPlayerData] : Not all data have been loaded, this function have to be fixed");
    }


}
