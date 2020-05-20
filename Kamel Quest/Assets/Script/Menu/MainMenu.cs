using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Author : Elouan

public class MainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("Game");
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
