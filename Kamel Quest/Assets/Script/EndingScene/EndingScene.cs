﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Author : Elouan
/// <summary>
/// The main <c>EndingScene</c> class.
/// Contains all methods for performing the ending scene.
/// <para> The ending scene will be load after the player kill the last boss of our game</para>
/// <list type="bullet">
/// <item>
/// <term>Leave</term>
/// <description>Is called when the player click on the button "LEAVE" and quit the application</description>
/// </item>
/// <item>
/// <term>LoadingEndingScene</term>
/// <description>Is called after the final boss death, it load the ending scene</description>
/// </item>
/// </list>
/// </summary>
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
