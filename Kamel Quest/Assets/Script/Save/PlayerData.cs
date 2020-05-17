using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//Author : Elouan

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    // Player 
    [Header("Player")]
    public int playerLevel;
    public int playerXP;
    public int playerMoney;
    public float[] playerPosition;
    public int[] playerEquipmentsLevel;

    // Player's team
    [Header("Player's team")]
    public int[] playerTeamHp;
    public int[] allyLevel;

    // Inventory
    [Header("Inventory")]
    public int[] inventoryIDSlots;
    public int[] inventoryCountSlots;

    // Settings
    [Header("Settings")]
    public float volumeSetting;
    public int qualityIndex;
    public bool isFullScreen;
    public int resolutionIndex;

    // Constructor

    public PlayerData(Player player, AudioMixer audioMixer)
    {   
        // Player
        playerLevel = player.lvl;
        playerXP = player.xp;
        playerMoney = player.argent;

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
        //Inventory
        inventoryCountSlots = player.inventoryCount;
        inventoryIDSlots = player.inventoryID;

        // Player's team
        playerTeamHp = new int[2];
        playerTeamHp[0] = player.team[0].currenthp;
        playerTeamHp[1] = player.team[1].currenthp;

        // Settings
        audioMixer.GetFloat(audioMixer.name, out volumeSetting);
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
