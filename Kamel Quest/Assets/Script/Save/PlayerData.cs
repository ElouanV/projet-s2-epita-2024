using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author : Elouan

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
    public float[] playerCameraPosition;
    public int[] playerEquipmentsLevel;


    // Quest Progress
    [Header("Quest Progress")]
    public int questfinish;
    public bool[] finishedquestannex;
    
    // Player's team
    [Header("Player's team")]
    public int[] playerTeamHp;
    public int[] allyxp;

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
            // Pick up variable to define camera's position in  a float arrat
        playerCameraPosition = new float[3];
        GameObject camera = GameObject.FindWithTag("MainCamera");
        playerCameraPosition[0] = camera.transform.position.x;
        playerCameraPosition[1] = camera.transform.position.y;
        playerCameraPosition[2] = camera.transform.position.z;
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
        allyxp = new int[2];
        allyxp[0] = ally1.Xp;
        allyxp[1] = ally2.Xp;

        // QUEST
            // For main quest
        Progression progression = player.GetComponent<Progression>();
        questfinish = progression.CurrentGetSet;
            // Annex quest
        finishedquestannex = progression.AnnexCompleted;


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
