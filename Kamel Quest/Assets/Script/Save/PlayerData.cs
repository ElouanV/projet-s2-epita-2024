using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author : Elouan
///<summary>
/// It's the main class <c>PlayerData</c> which tranform all information we need to save to bool, int float, stringg or arrays which are the only types supported by the binary serialization use in the save system
///</summar>
[System.Serializable]
public class PlayerData
{
    // Player 
    [Header("Player")]
    public int playerLevel;
    public int playerXP;
    public int playerMoney;
    public int playerKey;
    public float[] playerPosition;
    public int[] playerEquipmentsLevel;


    // Quest Progress
    [Header("Quest Progress")]
    public int questfinish;
    public int queststate;
    public bool[] finishedquestannex;

    //Fight progression :
    [Header("Fight progression")]
    public bool[] fightprogress;
    
    // Player's team
    [Header("Player's team")]
    public int[] playerTeamHp;

    // Inventory
    [Header("Inventory")]
    public int[] inventoryIDSlots;
    public int[] inventoryCountSlots;

    // Settings
    [Header("Settings")]
    public int qualityIndex;
    public bool isFullScreen;
    public int resolutionIndex;


    // Constructor

    public PlayerData(Player player)
    {   
        // PLAYER
        playerLevel = player.lvl;
        playerXP = player.xp;
        playerMoney = player.argent;
        playerKey = player.nbrOfKey;

            // Pick up variable to define player's position in a float array
        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;
            // Pick up variable to define player's equipment levels
        playerEquipmentsLevel = new int[3];
        playerEquipmentsLevel[0] = player.armurelvl;
        playerEquipmentsLevel[1] = player.epeelvl;
        playerEquipmentsLevel[2] = player.bouclierlvl;

        //INVENTORY
        inventoryCountSlots = player.inventoryCount;
        inventoryIDSlots = player.inventoryID;
    
        // TEAM
        playerTeamHp = new int[2];
        Entity ally1 = player._team[0].GetComponent<Entity>();
        Entity ally2 = player._team[1].GetComponent<Entity>();
        playerTeamHp[0] = ally1.currenthp;
        playerTeamHp[1] = ally2.currenthp;

        // QUEST
            // For main quest
        
        Progression progression = player.GetComponent<Progression>();

        questfinish = progression.CurrentGetSet;
            // Annex quest
        finishedquestannex = progression.AnnexCompleted;


        // MONSTER
        fightprogress = player.fightprogress;

        // SETTINGS
        qualityIndex = QualitySettings.GetQualityLevel();
        isFullScreen = Screen.fullScreen;
        Resolution[] resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionIndex = i;
            }
        }
    }
}
