using System.Collections;
using System.Collections.Generic;
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

    Player playerUnit;
    Ennemy enemyUnit;
    
    public BattleState state;
    public Text dialogue;
    
    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    public void SetupBattle() //faire spawn les entités au bonne endroit et mettre les UI a jour
    {
        GameObject playerObject = Instantiate(playerPrefab, playerSpawn);
        playerUnit = GetComponent<Player>();
        
        
        GameObject enemyObject = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = GetComponent<Ennemy>();

        dialogue.text = playerUnit.name;
        
        state = BattleState.PLAYERTURN;
    }

   

    

    public void AttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        
    }
    
    
    
    

 
}
