using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author : Settha and Elouan

/// <summary>
/// The main <c>PauseMenu</c> class.
/// Contains all methods for performing pause menu.
/// <para> The pause menu allow the player to acces to Settingsmenu, to save the party and go back to the mainmenu, or resume the game </para>
/// <list type="bullet">
/// <item>
/// <term>Update</term>
/// <description>This method is called each frame</description>
/// </item>
/// <item>
/// <term>StopTime</term>
/// <description> ... stop the time scale of the game</description>
/// </item>
/// <item>
/// <term>Resume</term>
/// <description>Resume the game</description>
/// </item>
/// <item>
/// <term>SaveAndQuit</term>
/// <description>Save the player's data and load mainmenu scene</description>
/// </item>
/// <term>OptionsMenu</term>
/// <description>give access to the settings menu</description>
/// </item>
/// </list>
/// </summary>
public class PauseMenu : MonoBehaviour
{
    private static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsUI;
    public Player player;
    private string menukey = "Menu";


    ///<summary>
    /// This methods is call each frame. It simply verify if the key "A" is pressed to resume or pause de game
    ///</summary>
    void Update()
    {
        if (Input.GetButtonDown(menukey))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                StopTime();
            }
        }
    }

    ///<summary>
    /// This methods stop the time scale of the game when the pause menu is open, close the inventory if it was open.
    ///<remarks> It set the cursor visble </remaks>
    ///</summary>
    public void StopTime()
    {
        PauseMenuUI.SetActive(true);
        player.GetComponent<Inventory_test>().pauseMenuOpen = true;
        player.GetComponent<Inventory_test>().ShowOrHideInventory();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPaused = true;
    }

    ///<summary>
    /// This method resume the game and the time scale, and close the pause menu.
    ///<remarks> It set the cursor invisible and lock it </remaks>
    ///</summary>   
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        player.GetComponent<Inventory_test>().pauseMenuOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    ///<summary>
    /// This method set active the settings menu.
    ///<remarks> It set the cursor invisible and lock it </remaks>
    ///</summary>  
    public void OptionsMenu()
    {
        OptionsUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

    ///<summary>
    /// This method saves the data of the player by calling the methods SavePlayer of the SaveSystem class.
    ///<remarks> It set the playerprefs "SaveExist" to one, which mean that a save exist and can be loaded. </remaks>
    ///</summary>  
    public void SaveAndQuit ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        SaveSystem.SavePlayer(player);
        PlayerPrefs.SetInt("SaveExist",1);
    }

}
