using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;


public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
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


    // Start is called before the first frame update
    void Start()
    {
        //team = GameObject.FindGameObjectWithTag("Player").GetComponent<Team>();
        state = BattleState.START;
        SetupBattle();
    }

    public void SetupBattle() //faire spawn les entités au bonne endroit et mettre les UI a jour
    {
        Random random = new Random();
        int numberEnemi = random.Next(1, 3);

        GameObject playerObject = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerObject.GetComponent<Entity>();

        GameObject ally1Object = Instantiate(ally1Prefab, ally1Spawn);
        ally1Unit = ally1Object.GetComponent<Entity>();

        GameObject ally2Object = Instantiate(ally2Prefab, ally2Spawn);
        ally2Unit = ally2Object.GetComponent<Entity>();


        if (numberEnemi == 1)
        {
            GameObject enemyObject = Instantiate(enemyPrefab, enemySpawn);
            enemyUnit = enemyObject.GetComponent<Entity>();
        }

        if (numberEnemi == 2)
        {
            GameObject enemyObject = Instantiate(enemyPrefab, enemySpawn);
            enemyUnit = enemyObject.GetComponent<Entity>();

            GameObject enemy1Object = Instantiate(enemy1Prefab, enemy1Spawn);
            enemyUnit = enemy1Object.GetComponent<Entity>();
        }

        if (numberEnemi == 3)
        {
            GameObject enemyObject = Instantiate(enemyPrefab, enemySpawn);
            enemyUnit = enemyObject.GetComponent<Entity>();

            GameObject enemy1Object = Instantiate(enemy1Prefab, enemy1Spawn);
            enemyUnit = enemy1Object.GetComponent<Entity>();

            GameObject enemy2Object = Instantiate(enemy2Prefab, enemy2Spawn);
            enemy2Unit = enemy2Object.GetComponent<Entity>();
        }








        dialogue.text = "Vous entrez en combat !";


        playerHUD.SetupHUD(playerUnit, ally1Unit, ally2Unit);

        if (numberEnemi == 1)
        {
            enemyHUD.SetupHUD(enemyUnit, null, null);
        }

        if (numberEnemi == 2)
        {
            enemyHUD.SetupHUD(enemyUnit, enemy1Unit, null);
        }

        if (numberEnemi == 3)
        {
            enemyHUD.SetupHUD(enemyUnit, enemy1Unit, enemy2Unit);
        }

        state = BattleState.PLAYERTURN;
    }






    //BattleSystem

    IEnumerator playerBasicAttack()
    {
        
        enemyUnit.GetHurt(playerUnit.Atk);
        enemyHUD.UpdateHp(enemyUnit.currenthp, enemyUnit);
        
        yield return new WaitForSeconds(1f);

        if (playerUnit.currenthp <= 0)
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
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(playerBasicAttack());
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
        throw new NotImplementedException();
    }


    public void PlayerTurn() // update de l'HUD dialogue
    {
        dialogue.text = "C'est votre tour";
    }

    void LoseBattle()
    {
        SceneManager.LoadScene("Game");
    }

    void WinBattle()
    {
        SceneManager.LoadScene("Game");
    }
    
    
    //bouton choix adversaire

    void attackEnemy(Entity unit, Entity player)
    {
        throw new NotImplementedException();
    }

    
    
    
    
    

 
}
