using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Author : Settha

public class EnterBattle : MonoBehaviour
{
    public int enemyid1;
    public int enemyid2;
    public int enemyid3;
    public int monsterID;
    // Start is called before the first frame update
    public bool is_active;
    public bool is_alive = true;
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
        PlayerPrefs.SetInt("Enemy1",enemyid1);
        PlayerPrefs.SetInt("Enemy2",enemyid2);
        PlayerPrefs.SetInt("Enemy3",enemyid3);
        PlayerPrefs.SetInt("monsterID", monsterID);
        SceneManager.LoadScene("FightScene");
    }
}
