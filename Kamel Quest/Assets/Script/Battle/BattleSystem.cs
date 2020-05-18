﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Author : Settha

public enum BattleState
{
    START,
    PLAYERTURN,
    PLAYERTURN1,
    PLAYERTURN2,
    ENEMYTURN,
    ENEMYTURN1,
    ENEMYTURN2,
    WIN,
    LOSE
}
public class BattleSystem : MonoBehaviour
{
    /*
     * je mettrai les commentaires XML plus tard
     */
    
    
    //gestion de team
    //private Team team;
    
    

    
    //prefab pour afficher les personnages dans le combat
    public GameObject playerPrefab; //joueur
    public GameObject enemyPrefab;  // enemy
    public GameObject enemy1Prefab;  // enemy
    public GameObject enemy2Prefab;  // enemy
    public GameObject ally1Prefab; 
    public GameObject ally2Prefab;
    
    
    public Transform playerSpawn; //position de spawn
    public Transform enemySpawn;  //position de spawn
    public Transform enemy1Spawn;  //position de spawn
    public Transform enemy2Spawn;  //position de spawn
    public Transform ally1Spawn; //position de spawn
    public Transform ally2Spawn;
    
    
    

    private Entity playerUnit;
    private Entity enemyUnit;
    private Entity enemy1Unit;
    private Entity enemy2Unit;
    private Entity ally1Unit;
    private Entity ally2Unit;
    
    public BattleState state;
    public TextMeshProUGUI dialogue;
    
    //gestion des HUD de combats (affichage)
    public BattleUI playerHUD;
    public BattleUI enemyHUD;
    public GameObject ChooseEnemyCanvas;
    public GameObject BattleButtonCanvas;
    


    // Start is called before the first frame update
    void Start()
    {
        //team = GameObject.FindGameObjectWithTag("Player").GetComponent<Team>();
        state = BattleState.START;
        SetupBattle();
    }

    public void SetupBattle() //faire spawn les entités au bonne endroit et mettre les UI a jour
    {
        GameObject playerObject = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerObject.GetComponent<Entity>();
        
        GameObject ally1Object = Instantiate(ally1Prefab, ally1Spawn);
        ally1Unit = ally1Object.GetComponent<Entity>();
        
        GameObject ally2Object = Instantiate(ally2Prefab, ally2Spawn);
        ally2Unit = ally2Object.GetComponent<Entity>();

        GameObject enemyObject = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyObject.GetComponent<Entity>();
        
        GameObject enemy1Object = Instantiate(enemy1Prefab, enemy1Spawn);
        enemy1Unit = enemy1Object.GetComponent<Entity>();
        
        GameObject enemy2Object = Instantiate(enemy2Prefab, enemy2Spawn);
        enemy2Unit = enemy2Object.GetComponent<Entity>();

        dialogue.text = "Vous entrez en combat !";
        
        
        playerHUD.SetupHUD(playerUnit, ally1Unit, ally2Unit);
        enemyHUD.SetupHUD(enemyUnit, enemy1Unit, enemy2Unit);
        
        state = BattleState.PLAYERTURN;
    }




    
    //BattleSystem

    IEnumerator playerBasicAttack(Entity plUnit, Entity enUnit)
    {
        enUnit.GetHurt(plUnit.Atk);
        enemyHUD.UpdateHp(enUnit.currenthp, enUnit);
        
        yield return new WaitForSeconds(1f);

        if (plUnit.currenthp <= 0)
        {
            state = BattleState.LOSE;
            LoseBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    

    IEnumerator playerHealSpell()
    {
        playerUnit.GetHeal(5);
        playerHUD.UpdateHp(playerUnit.currenthp, playerUnit);
        yield return new WaitForSeconds(1f);
        
        
        
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        playerUnit.GetHurt(enemyUnit.Atk);
        playerHUD.UpdateHp(playerUnit.currenthp, playerUnit);
        yield return new WaitForSeconds(1f);

        if (enemyUnit.currenthp <= 0)
        {
            state = BattleState.WIN;
            WinBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
        }
        

    }

    public void SpellButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(playerHealSpell());
    }


    public void AttackButton()
    {
        BattleButtonCanvas.SetActive(false);
        ChooseEnemyCanvas.SetActive(true);
    }

    public void SkipButton()
    {
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void InventoryButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            
        }
        throw new NotImplementedException("FIXE ME BITCH");
    }


    public void PlayerTurn() // update de l'HUD dialogue
    {
        dialogue.text = "C'est votre tour";
    }

    public void ChooseEnemy()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        BattleButtonCanvas.SetActive(true);
        ChooseEnemyCanvas.SetActive(false);
        StartCoroutine(playerBasicAttack(playerUnit,enemyUnit));
    }
    public void ChooseEnemy1()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        BattleButtonCanvas.SetActive(true);
        ChooseEnemyCanvas.SetActive(false);
        StartCoroutine(playerBasicAttack(playerUnit,enemy1Unit));
    }
    public void ChooseEnemy2()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        BattleButtonCanvas.SetActive(true);
        ChooseEnemyCanvas.SetActive(false);
        StartCoroutine(playerBasicAttack(playerUnit,enemy2Unit));
    }
    
    
    
    
    
    
    
    //End Battle
    void LoseBattle()
    {
        SceneManager.LoadScene("Game");
    }

    void WinBattle()
    {
        SceneManager.LoadScene("Game");
    }
    
    
    
    
    
    

 
}
