using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author : Elouan
/// <summary>
/// The main <c>PlayerData</c> class.
/// Contains all methods for performing the convertion of all you player's data to string, float, int , bool or arrays.
/// <para> The inventory is composed by 20 inventorySlots, each slot can countain 64 items with the same ID </para>
/// <remaks> To save our data, we can only use arrays, bool, string, int and float variables. 
/// </summary>
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
    public bool[] finishedquestprogress;

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
    public int qualityIndex;
    public bool isFullScreen;
    public int resolutionIndex;


    // Constructor
    ///<summary> Thie methhod is the constructor of our PlayerData, it will be called to load a game and save a game.
    ///<param Name = "player"> is the player we need to save datas </param>
    ///<para> This constructor convert all player datas we need to save to types which are accept by our SaveSystem.</para>
    ///</summary>
    public PlayerData(Player player)
    {   
        // Player
        playerLevel = player.lvl;
        playerXP = player.xp;
        playerMoney = player.argent;
        playerKey = player.nbrOfKey;

            // Pick up variable to define player's position in a float array
        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;
            // Pick up variable to define player's equipments levels
        playerEquipmentsLevel = new int[3];
        playerEquipmentsLevel[0] = player.armurelvl;
        playerEquipmentsLevel[1] = player.epeelvl;
        playerEquipmentsLevel[2] = player.bouclierlvl;
        //Inventory
        inventoryCountSlots = player.inventoryCount;
        inventoryIDSlots = player.inventoryID;

        // Player's team
        playerTeamHp = new int[2];
        playerTeamHp[0] = Player.team[0].GetComponent<Entity>().currenthp;
        playerTeamHp[1] = Player.team[1].GetComponent<Entity>().currenthp;

        // Quest progress
        finishedquestprogress = new bool[player.GetComponent<Progression>().Prog.Count];
        for (int i = 0; i < player.GetComponent<Progression>().Prog.Count; i++)
        {
            if (player.GetComponent<Progression>().Prog[i] == null)
            {
                finishedquestprogress[i] = true;
            }
            else
            {
                finishedquestprogress[i] = false;
            }
        }



        // Settings
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
