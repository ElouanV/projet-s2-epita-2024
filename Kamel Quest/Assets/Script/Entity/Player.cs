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
    public GameObject[] beatenMonster;
    public bool[] fightprogress;
    public int questfinish;


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

    ///<summary> Verify the presence  of an item in the player's inventory
    ///<param Name = "id"> Corresponding to the ID of the item search </param>
    ///<param Name = "needed"> The amount needed</param>
    ///<remarks> This method can be call even in a scene where inventory gameobject are not present, in the FightScene for exemple </remaks>
    ///</summary>
    public bool IsInInventory(int ID, int needed)
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
    ///<summary> Remount the total amount of on given item in the player's inventory
    ///<param Name = "id"> Corresponding to the ID of the item search </param>
    ///<remarks> This method can be call even in a scene where inventory gameobject are not present, in the FightScene for exemple </remaks>
    ///</summary>
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

    ///<summary> Add one item corresponding to the ID given in the player inventory
    ///<param Name = "id"> Corresponding to the ID of the item to add </param>
    ///<remarks> This method can be call even in a scene where inventory gameobject are not present, in the FightScene for exemple </remaks>
    ///</summary>
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
    ///<summary> Remove one item corresponding to the ID given in the player inventory
    ///<param Name = "id"> Corresponding to the ID of the item to remove </param>
    ///<remarks> This method can be call even in a scene where inventory gameobject are not present, in the FightScene for exemple </remaks>
    ///</summary>
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
    ///<remarks> To understand well this part, you should start to read <c>SaveSystem</c> and <c> PlayerData</c> classes </remarks>
    ///<para> This part is use to load player data, methods called on the Start() function depands of the precedent action, assigned by the player pref. If the player  pref is equal to 1, the Start() will simply load the saved game.</para>
    ///<para> If playerpref "loaddata" is equal to 2, it load a new party </para>
    ///<para> If the player "loaddata" is equal to 3, it signify that we are loding data on the fightscene, and the methods  call will be different because on the fight scene, some gameobject are missing compare to the game scene. Inventory and quests are missing for exemple </para>
    ///
    ///</summary>
    [Header ("For save")]
    public GameObject swordslot;
    public GameObject shieldslot;
    public GameObject armorslot;
    public GameObject keyslot;

    ///<summary>
    /// This methods just called the methods of the SaveSystem with argument this player.
    /// This methods wiill be called when the player want to go back to the main menu or before a scene switching
    ///</summar>
    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this);

    }
    ///<summary>
    /// The Start() methods is called one the first frame of a scene, this one load require data in the player of the new scene. Method called depend of the value of the player pref "LoadData".
    ///</summar>
    private void Start()
    {

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
    ///<summary>
    /// This method is called if a save file exist and if we are loading data on the Game scene
    /// It load all progression datas of the player, monster killed, quest finished and position on the scene.
    ///</summary>
    public void LoadPlayerData()
    {
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
        
        // MOSNTER
        fightprogress = data.fightprogress;
        LoadMonsterData();

        // QUEST 
        Progression progression = transform.GetComponent<Progression>();
        LoadQuestProgress(data.questfinish);
        LoadQuestProgressAnnex(data.finishedquestannex, progression);
        
        

        //POSITION
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        transform.position = position;

    }

    ///<summary>
    /// This method is called if a save file exist and if we are loading data on the Game scene. 
    /// It add item of the player's inventory in the inventory gameobject (which is the interface which display item contain in the inventory)
    ///</summary>
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

    ///<summary>
    /// This method is called if a save file exist and if we are loading data on the Game scene. 
    /// Same as LoadQuestProgress, but on annex quests.
    ///</summary>
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
    }

    ///<summary>
    /// This method is called if a save file exist and if we are loading data on the Game scene. 
    /// It destroy achived quests and set active the current quest
    ///</summary>
    private void LoadQuestProgress(int lastquest)
    {

        Progression progression = transform.GetComponent<Progression>();
        progression.CurrentQuestGetSet = progression.Prog[0];
        for (int i = 0; i < lastquest; i++)
        {
            progression.NextQuest();
        }
    }


    ///<summary>
    /// This method is called if a save file exist and if we are loading data on the Game scene and when we are on the fightscene
    /// Load the lvl of the equipement of the player.
    ///</summary>
    private void LoadQuestProgressAnnex(bool[] questprogress, Progression progression)
    {
        for (int i = 0; i < questprogress.Length; i++)
        {
            progression.UpdateAnexCompleted(progression.ProgAnex[i], i);
        }
    }

    ///<summary>
    /// This method is called if a save file exist and if we are loading data on the Game scene. 
    /// As LoadInventory, it load equipment lvl and sppirte on the inventory interface.
    ///</summary>
    public void LoadEquipementTeam(Entity ally1, Entity ally2, int lvl)
    {
        int atkboost = epeeboost[epeelvl-1];
        int hpboost = armureboost[armurelvl-1];
        ally1.atk += atkboost;
        ally2.atk += atkboost;
        ally1.hpmax += hpboost;
        ally1.hpmax += hpboost;
    }
    ///<summary>
    /// This method is called if a save file exist and if we are loading data on the Game scene. 
    /// Destroy all the monster already defeated.
    ///</summary>
    private void LoadMonsterData()
    {
        for (int i = 0; i < fightprogress.Length; i++)
        {
            if (fightprogress[i] &&  beatenMonster[i].GetComponent<EnterBattle>().is_active)
            {
                Destroy(beatenMonster[i]);
            }
            if(fightprogress[i] && !beatenMonster[i].GetComponent<EnterBattle>().is_active)
            {
                beatenMonster[i].GetComponent<IsKilled>().UpdateState();
            }
        }
    }

    ///<summary>
    /// This method is called to create a new party on the Game scene
    ///</summary>
    private void CreateNewParty()
    {
        // Create player statitics
        argent = 150;
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
            //Default values
        // Load quest datas
            //Default valaues
        //Load player's position
        Vector3 position;
        // Tutorial position 
        position.x = 1.9f;
        position.y = -67.1f;     
        position.z = 0f;
        transform.position = position;
    }

    ///<summary>
    /// This method is called in the FightScene
    /// It load only data require in the FightScene and keep save the data which we will need to load at the end of the fight.
    ///</summary>
    public void LoadPlayerForBattle()
    {
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
        

        Progression progression = transform.GetComponent<Progression>();
        progression.CurrentGetSet = data.questfinish;
        progression.AnnexCompleted = data.finishedquestannex;
        
        // MOSNTER
        fightprogress = data.fightprogress;

        //POSITION
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        transform.position = position;

    }


}
