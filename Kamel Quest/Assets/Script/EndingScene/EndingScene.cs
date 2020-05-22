using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public void Leave()
    {
        Application.Quit();
    }

    public void LoadEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}


//x  0
//y -6.38
//z -30