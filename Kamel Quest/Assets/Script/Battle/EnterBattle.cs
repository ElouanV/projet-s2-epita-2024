using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Author : Settha

public class EnterBattle : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_active;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && is_active)
        {
            EnterBattlePlayer();
        }
    }
    public void EnterBattlePlayer()
    {
        GameObject goplayer = GameObject.FindWithTag("Player");
        Player player = goplayer.GetComponent<Player>();
        SaveSystem.SavePlayer(player);
        PlayerPrefs.SetInt("LoadData",3);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("FightScene");
    }
}
