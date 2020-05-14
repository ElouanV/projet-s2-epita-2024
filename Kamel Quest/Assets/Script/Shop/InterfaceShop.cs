using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Authors : Martin
public class InterfaceShop : MonoBehaviour
{
    public void PlayShop()
    {
        SceneManager.LoadScene("Martin - Shop");
    }

    public void QuitShop()
    {
        Application.Quit();
    }
}
