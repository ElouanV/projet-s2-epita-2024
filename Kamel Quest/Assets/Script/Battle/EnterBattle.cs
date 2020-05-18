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
            SceneManager.LoadScene("FightScene");
        }
    }
}
