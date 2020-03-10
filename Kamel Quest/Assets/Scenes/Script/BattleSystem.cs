using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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
    
    public GameObject playerPrefab; //joueur
    public GameObject enemyPrefab;  // enemy
    public Transform playerSpawn; //position de spawn
    public Transform enemySpawn;  //position de spawn

    Entity playerUnit;
    private Entity enemyUnit;
    
    public BattleState state;
    public TextMeshProUGUI dialogue;
    
    //gestion des HUD de combats (affichage)
    public BattleUI playerHUD;
    public BattleUI enemyHUD;
    
    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    public void SetupBattle() //faire spawn les entités au bonne endroit et mettre les UI a jour
    {
        GameObject playerObject = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerObject.GetComponent<Entity>();
        
        
        GameObject enemyObject = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyObject.GetComponent<Entity>();
        
        
        
        playerHUD.SetupHUD(playerUnit);
        enemyHUD.SetupHUD(enemyUnit);
        
        state = BattleState.PLAYERTURN;
    }

    public void PlayerTurn()
    {
        throw new NotImplementedException();
    }



    IEnumerator playerBasicAttack()
    {
        enemyUnit.GetHurt(playerUnit.Atk);
        enemyHUD.UpdateHp(enemyUnit.currenthp);
        
        yield return new WaitForSeconds(2f);
    }


    public void AttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(playerBasicAttack());


    }
    
    
    
    

 
}
