using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
// Author : Settha and Elouan
public class PauseMenu : MonoBehaviour
{
    private static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsUI;
    public AudioMixer audioMixer;
    public Player player;
    private string menukey = "Menu";

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

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        player.GetComponent<Inventory_test>().pauseMenuOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OptionsMenu()
    {
        Debug.Log("Set options menu active");
        OptionsUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

    public void SaveAndQuit ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        SaveSystem.SavePlayer(player, audioMixer);
        Debug.Log("Data have been save");
        PlayerPrefs.SetInt("SaveExist",1);
    }

}
