using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Author : Elouan

/// <summary>
/// The main <c>Inventory_test</c> class.
/// Contains all methods for performing the player's inventory.
/// <para> The inventory is composed by 20 inventorySlots, each slot can countain 64 items with the same ID </para>
/// <list type="bullet">
/// <item>
/// <term>Start</term>
/// <description>Is called before the first frame update</description>
/// </item>
/// <item>
/// <term>Update</term>
/// <description>Is called once per frame</description>
/// </item>
/// <item>
/// <term>AddToInventory</term>
/// <description>Add an item in the inventory</description>
/// </item>
/// <item>
/// <term>RemoveFromInventory</term>
/// <description>Remove an item in the inventory</description>
/// </item>
/// </list>
/// </summary>
public class MainMenu : MonoBehaviour
{
    
    public GameObject SceneLoader;
    public GameObject noSave;

    ///<summary> Open the playgame menu 
    ///<remaks> is called when the user click on "PLAY" button </remaks>
    ///<summary>
    public void PlayGame()
    {
        gameObject.SetActive(false);
    }

    ///<summary> Close the apllication
    ///<remaks> is called when the user click on "QUIT" button </remaks>
    ///<summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    ///<summary> Start a new game 
    ///<remaks> is called when the user click on "NEW GAME" button on the playgame menu </remaks>
    ///<summary>
    public void NewGame()
    {
        PlayerPrefs.SetInt("LoadData",2);
        SceneLoader.GetComponent<SceneLoader>().LoadScene(1);
    }

    ///<summary> Load the saved game
    ///<remaks> is called when the user click on "LOAD GAME" button on the playgame menu </remaks>
    ///<remaks> If there is no save avaible and the play try to click on this button, nothing is appening and a text appear the signal that there is no save to load.
    ///<summary>
    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("SaveExist",0) == 1)
        {
            PlayerPrefs.SetInt("LoadData", 1);
            SceneLoader.GetComponent<SceneLoader>().LoadScene(1);
            PlayerPrefs.DeleteKey("SaveExist");
        }
        else
        {
            noSave.SetActive(true);
        }
        
    }



    // Comments on the PlayerPrefs "LoadData" : 
    // If LoadData = 1 The game will download data saved on the party
    // If LoadData = 2 The game will create a new game
    // The default value of LoadData is 0, but both methods which can load a game define it in another case.
    // The Start methods of Player class will use PlayerPrefs LoadData to know if it have to load a game or not
    //
    // Comments on the playerprefs "SaveExist" : 
    // If a party have been saved in the pass, "SaveExist" is equal to one and signify a saved party could be load
    // Else, SaveExist is by default equal to 0 and means there is no save which can be loaded.
    // This value is set in the PauseMenu class when the methode "SaveAndQuit" is called.

}
