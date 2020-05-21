using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Author : Elouan

public class MainMenu : MonoBehaviour
{
    public GameObject noSave;
    public void PlayGame()
    {
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


    public void NewGame()
    {
        PlayerPrefs.SetInt("LoadData",2);
        SceneManager.LoadScene("Game");
        Debug.Log("Prefs Load : " + PlayerPrefs.GetInt("LoadData",0));
    }


    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("SaveExist",0) == 1)
        {
            PlayerPrefs.SetInt("LoadData",1);
            SceneManager.LoadScene("Game");
        }
        else
        {
            noSave.SetActive(true);
            Debug.Log(" NoSave Active");
        }
        
    }

    // If LoadData = 1 The game will download data saved on the party
    // If LoadData = 2 The game will create a new game
    // The default value of LoadData is 0, but both methods which can load a game define it in another case.

}
