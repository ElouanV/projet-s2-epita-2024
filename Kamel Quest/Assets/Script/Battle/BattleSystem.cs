using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;


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

    public Image playerSpawnUI;
    public Image ally1SpawnUI;
    public Image ally2SpawnUI;
    public Image enemySpawnUI;
    public Image enemy1SpawnUI;
    public Image enemy2SpawnUI;



    //compteur de tour
    private int nbTurn;
    private bool loot;


    //gestion de team
    public Player player;
    public GameObject[] allyList;

    //private Team team;

    public GameObject[] enemyList = new GameObject[3];
    private Entity[] enemyteam = new Entity[3];


    //prefab pour afficher les personnages dans le combat
    public GameObject playerPrefab; //joueur
    private GameObject enemyPrefab; // enemy
    private GameObject enemy1Prefab; // enemy
    private GameObject enemy2Prefab; // enemy
    public GameObject ally1Prefab;
    public GameObject ally2Prefab;


    public Transform playerSpawn; //position de spawn
    public Transform enemySpawn; //position de spawn
    public Transform enemy1Spawn; //position de spawn
    public Transform enemy2Spawn; //position de spawn
    public Transform ally1Spawn; //position de spawn
    public Transform ally2Spawn;




    private Player playerUnit;
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
    public GameObject InventoryCanvas;



    // Start is called before the first frame update
    void Start()
    {
        nbTurn = 0;
        //desactivation de la caméra attachée au player
        //player.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        
        allyList = player._team;
        //player.gameObject.SetActive(false);

        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    

    IEnumerator SetupBattle() //faire spawn les entités au bon endroit et mettre les UI a jour
    {
        Random random = new Random();
        int numberEnemy = 3;
        int wichEnemy = random.Next(0, 3);
        
        
        


        playerPrefab.GetComponent<Player>().LoadPlayerForBattle();
        GameObject playerObject = GameObject.FindWithTag("Player");
        playerUnit = playerObject.GetComponent<Player>();
        playerUnit.LoadPlayerForBattle();

//---------------------------------------------------
        Debug.Log("We are downloading your party, please wait");
        //Get player data from binary save file
        PlayerData data = SaveSystem.LoadPlayer();

        // PLAYER
        playerUnit.argent = data.playerMoney;
        playerUnit.nbrOfKey = data.playerKey;
        int playerxp = data.playerXP;
        playerUnit.GetXp(playerxp);

        //EQUIPMENTS
        playerUnit.armurelvl = data.playerEquipmentsLevel[0];
        playerUnit.epeelvl = data.playerEquipmentsLevel[1];
        playerUnit.bouclierlvl = data.playerEquipmentsLevel[2];

        //INVENTORY
        playerUnit.inventoryCount = data.inventoryCountSlots;
        playerUnit.inventoryID  = data.inventoryIDSlots;

        //TEAM
        Entity ally1 = playerUnit._team[0].GetComponent<Entity>();
        Entity ally2 = playerUnit._team[1].GetComponent<Entity>();
        ally1.GetXp(playerxp);
        ally2.GetXp(playerxp);
        playerUnit.LoadEquipementTeam(ally1, ally2, playerUnit.lvl);
        ally1.currenthp = data.playerTeamHp[0];
        ally2.currenthp = data.playerTeamHp[1];
        

        Progression progression = playerUnit.transform.GetComponent<Progression>();
        progression.CurrentGetSet = data.questfinish;
        progression.AnnexCompleted = data.finishedquestannex;
        
        // MOSNTER
        playerUnit.fightprogress = data.fightprogress;

        //POSITION
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];          
        position.z = data.playerPosition[2];
        playerUnit.transform.position = position;


        Debug.Log("[LoadPlayerData] :READY FOR THE FIGHT" + this);


//---------------------------------------------------------------------      
        playerSpawnUI.sprite = playerPrefab.GetComponent<SpriteRenderer>().sprite;
        if (!playerUnit.isalive)
        {
            playerUnit.GetComponentInChildren<Renderer>().enabled = false;
            playerSpawnUI.enabled = false;
            playerUnit = null;
        }
        
        ally1Prefab = allyList[0];
        GameObject ally1Object = Instantiate(ally1Prefab, ally1Spawn);
        ally1Unit = ally1Object.GetComponent<Entity>();
        ally1SpawnUI.sprite = ally1Prefab.GetComponentInChildren<SpriteRenderer>().sprite;
        if (!ally1Unit.isalive)
        {
            ally1Unit.GetComponentInChildren<Renderer>().enabled = false;
            ally1SpawnUI.enabled = false;
            ally1Unit = null;
        }
        
        ally2Prefab = allyList[1];
        GameObject ally2Object = Instantiate(ally2Prefab, ally2Spawn);
        ally2Unit = ally2Object.GetComponent<Entity>();
        ally2SpawnUI.sprite = ally2Prefab.GetComponentInChildren<SpriteRenderer>().sprite;
        if (!ally2Unit.isalive)
        {
            ally2Unit.GetComponentInChildren<Renderer>().enabled = false;
            ally2SpawnUI.enabled = false;
            ally2Unit = null;
        }


        enemyPrefab = enemyList[PlayerPrefs.GetInt("Enemy1",0)];
        wichEnemy = random.Next(0, 2);
        enemy1Prefab = enemyList[PlayerPrefs.GetInt("Enemy2",0)];
        wichEnemy = random.Next(0, 2);
        enemy2Prefab = enemyList[PlayerPrefs.GetInt("Enemy3",0)];
        
        GameObject enemyObject = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyObject.GetComponent<Entity>();
        enemyteam[0] = enemyUnit;
        enemySpawnUI.sprite = enemyPrefab.GetComponentInChildren<SpriteRenderer>().sprite;

        GameObject enemy1Object = Instantiate(enemy1Prefab, enemy1Spawn);
        enemy1Unit = enemy1Object.GetComponent<Entity>();
        enemyteam[1] = enemy1Unit;
        enemy1SpawnUI.sprite = enemy1Prefab.GetComponentInChildren<SpriteRenderer>().sprite;

        GameObject enemy2Object = Instantiate(enemy2Prefab, enemy2Spawn);
        enemy2Unit = enemy2Object.GetComponent<Entity>();
        enemyteam[2] = enemy2Unit;
        enemy2SpawnUI.sprite = enemy2Prefab.GetComponentInChildren<SpriteRenderer>().sprite;

        enemyUnit.GetXp(player.Xp);
        enemy1Unit.GetXp(player.Xp);
        enemy2Unit.GetXp(player.Xp);

        

        dialogue.text = "Vous entrez en combat !";


        playerHUD.SetupHUD(playerUnit, ally1Unit, ally2Unit);

        if (numberEnemy == 1)
        {
            enemyHUD.SetupHUD(enemyUnit, enemy1Unit, enemy2Unit);
        }

        if (numberEnemy == 2)
        {
            enemyHUD.SetupHUD(enemyUnit, enemy1Unit, enemy2Unit);
        }

        if (numberEnemy == 3)
        {
            enemyHUD.SetupHUD(enemyUnit, enemy1Unit, enemy2Unit);
        }

        
        yield return new WaitForSeconds(1f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }






    //BattleSystem

    IEnumerator playerBasicAttack(Entity plUnit, Entity enUnit)
    {

        enUnit.GetHurt(plUnit.Atk);
        if (enUnit == enemyUnit)
        {
            enemyHUD.UpdateHp(enUnit.currenthp, enUnit, enemyHUD.hpSlider, enemyHUD.unitHpText); 
        }
        if (enUnit == enemy1Unit)
        {
            enemyHUD.UpdateHp(enUnit.currenthp, enUnit, enemyHUD.ally1HpSlider, enemyHUD.ally1HpText); 
        }
        if (enUnit == enemy2Unit)
        {
            enemyHUD.UpdateHp(enUnit.currenthp, enUnit, enemyHUD.ally2HpSlider, enemyHUD.ally2HpText); 
        }

        dialogue.text = "Tu peux mieux faire quand même";
        yield return new WaitForSeconds(1f);

        if (!playerUnit.isalive && !ally1Unit.isalive && !ally2Unit.isalive )
        {
            dialogue.text = "Zut ! Tu es mort";
            yield return new WaitForSeconds(1f);
            state = BattleState.LOSE;
            LoseBattle();
        }
        else
        {
            if (!enUnit.isalive && enUnit == enemyUnit)
            {
                dialogue.text = enUnit.name + " est mort !";
                yield return new WaitForSeconds(1f);
                enemyUnit.GetComponentInChildren<Renderer>().enabled = false;
                enemySpawnUI.enabled = false;

            }
            if (!enUnit.isalive && enUnit == enemy1Unit)
            {
                dialogue.text = enUnit.name + " est mort !";
                yield return new WaitForSeconds(1f);
                enemy1Unit.GetComponentInChildren<Renderer>().enabled = false;
                enemy1SpawnUI.enabled = false;
                
            }
            if (!enUnit.isalive && enUnit == enemy2Unit)
            {
                dialogue.text = enUnit.name + " est mort !";
                yield return new WaitForSeconds(1f);
                enemy2Unit.GetComponentInChildren<Renderer>().enabled = false;
                enemy2SpawnUI.enabled = false;
                
            }
            
            Random random = new Random();
            int selectAlly = random.Next(1, 4);
            changingStateEnemy(selectAlly);
        }
    }
    

    //FIXE ME
    IEnumerator playerHealSpell(Entity plUnit, Entity enUnit)
    {
        plUnit.GetHeal(plUnit.MagicAtk);
        playerHUD.UpdateHp(plUnit.currenthp, plUnit, playerHUD.hpSlider, playerHUD.unitHpText);
        yield return new WaitForSeconds(1f);
        
        switch (state)
        {
            case BattleState.PLAYERTURN :
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn(plUnit, enemyUnit));
                break;
            case BattleState.PLAYERTURN1:
                state = BattleState.ENEMYTURN1;
                StartCoroutine(EnemyTurn(plUnit, enemy1Unit));
                break;
            case BattleState.PLAYERTURN2:
                state = BattleState.ENEMYTURN2;
                StartCoroutine(EnemyTurn(plUnit, enemy2Unit));
                break;
        }
    }

    IEnumerator EnemyTurn(Entity plUnit, Entity enUnit)
    {
        /*if (plUnit.is_defence)
        {
            plUnit.GetHurt(enUnit.Atk/2);
            plUnit.is_defence = false;
        }
        else
        {
            plUnit.GetHurt(enemyUnit.Atk);
        }*/

        dialogue.text = enUnit.name + " attaque !";
        yield return new WaitForSeconds(1f);
        
        plUnit.GetHurt(enUnit.atk);

        if (plUnit == playerUnit)
        {
            playerHUD.UpdateHp(playerUnit.currenthp, playerUnit, playerHUD.hpSlider, playerHUD.unitHpText);
        }
        if (plUnit == ally1Unit)
        {
            playerHUD.UpdateHp(ally1Unit.currenthp, ally1Unit, playerHUD.ally1HpSlider, playerHUD.ally1HpText); 
        }
        if (plUnit == ally2Unit)
        {
            playerHUD.UpdateHp(plUnit.currenthp, plUnit, playerHUD.ally2HpSlider, playerHUD.ally2HpText); 
        }

        dialogue.text = "Ton adversaire est plus doué que toi...";
        yield return new WaitForSeconds(1f);
        dialogue.text = "Que vas tu faires maintenant ?";

        if (!enemyUnit.isalive  && !enemy1Unit.isalive   && !enemy2Unit.isalive)
        {
            dialogue.text = "Vous avez vaincu les monstres !";
            yield return new WaitForSeconds(1f);
            state = BattleState.WIN;
            WinBattle();
        }
        else
        {
            if (!plUnit.isalive && plUnit == playerUnit)
            {
                dialogue.text = plUnit.name + " est mort !";
                yield return new WaitForSeconds(1f);
                playerUnit.GetComponentInChildren<Renderer>().enabled = false;
                playerSpawnUI.enabled = false;

            }
            if (!plUnit.isalive && plUnit == ally1Unit)
            {
                dialogue.text = plUnit.name + " est mort !";
                yield return new WaitForSeconds(1f);
                ally1Unit.GetComponentInChildren<Renderer>().enabled = false;
                ally1Unit.enabled = false;

            }
            if (!plUnit.isalive && plUnit == ally2Unit)
            {
                dialogue.text = plUnit.name + " est mort !";
                yield return new WaitForSeconds(1f);
                ally2Unit.GetComponentInChildren<Renderer>().enabled = false;
                ally2Unit.enabled = false;
            }

            changingStatePlayer();
            
        }
        

    }
    
    
    //FIXE ME !
    public void SpellButton()
    {
        if (state != BattleState.PLAYERTURN || state != BattleState.PLAYERTURN1 || state != BattleState.PLAYERTURN2)
        {
            return;
        }

        StartCoroutine(playerHealSpell(playerUnit, enemyUnit));
    }


    public void AttackButton()
    {
        BattleButtonCanvas.SetActive(false);
        ChooseEnemyCanvas.SetActive(true);
    }

    
    //FIXE plUnit random
    public void SkipButton()
    {
        switch (state)
        {
            case BattleState.PLAYERTURN:
                playerUnit.is_defence = true;
                break;
            case BattleState.ENEMYTURN1:
                ally1Unit.is_defence = true;
                break;
            case BattleState.PLAYERTURN2:
                ally2Unit.is_defence = true;
                break;
        }
        
        Random random = new Random();
        int randomEntity = random.Next(1, 4);
        changingStateEnemy(randomEntity);
    }

    public void InventoryButton()
    {
        BattleButtonCanvas.SetActive(false);
        InventoryCanvas.SetActive(true);
    }


    public void PlayerTurn() // update de l'HUD dialogue
    {
        dialogue.text = "A toi de jouer !";
    }

    public void ChooseEnemy()
    {
        if (state == BattleState.ENEMYTURN || state == BattleState.ENEMYTURN1 || state == BattleState.ENEMYTURN2 || !enemyUnit.isalive)
        {
            dialogue.text = "Cet adversaire est déjà mort !";
            return;
        }
        ChooseEnemyCanvas.SetActive(false);
        BattleButtonCanvas.SetActive(true);
        
        switch (state)
        {
            case BattleState.PLAYERTURN :
                StartCoroutine(playerBasicAttack(playerUnit, enemyUnit));
                break;
            case BattleState.PLAYERTURN1:
                StartCoroutine(playerBasicAttack(ally1Unit, enemyUnit));
                break;
            case BattleState.PLAYERTURN2:
                StartCoroutine(playerBasicAttack(ally2Unit, enemyUnit));
                break;
        }
    }
    public void ChooseEnemy1()
    {
        if (state == BattleState.ENEMYTURN || state == BattleState.ENEMYTURN1 || state == BattleState.ENEMYTURN2 || !enemy1Unit.isalive)
        {
            dialogue.text = "Cet adversaire est déjà mort !";
            return;

        }
        ChooseEnemyCanvas.SetActive(false);
        BattleButtonCanvas.SetActive(true);
        switch (state)
        {
            case BattleState.PLAYERTURN :
                StartCoroutine(playerBasicAttack(playerUnit, enemy1Unit));
                break;
            case BattleState.PLAYERTURN1:
                StartCoroutine(playerBasicAttack(ally1Unit, enemy1Unit));
                break;
            case BattleState.PLAYERTURN2:
                StartCoroutine(playerBasicAttack(ally2Unit, enemy1Unit));
                break;
        }
    }
    public void ChooseEnemy2()
    {
        if (state == BattleState.ENEMYTURN || state == BattleState.ENEMYTURN1 || state == BattleState.ENEMYTURN2 || !enemy2Unit.isalive)
        {
            dialogue.text = "Cet adversaire est déjà mort !";
            return;
        }
        ChooseEnemyCanvas.SetActive(false);
        BattleButtonCanvas.SetActive(true);
        switch (state)
        {
            case BattleState.PLAYERTURN :
                StartCoroutine(playerBasicAttack(playerUnit, enemy2Unit));
                break;
            case BattleState.PLAYERTURN1:
                StartCoroutine(playerBasicAttack(ally1Unit, enemy2Unit));
                break;
            case BattleState.PLAYERTURN2:
                StartCoroutine(playerBasicAttack(ally2Unit, enemy2Unit));
                break;
        }
    }
    
    //retour en arrière
    public void BackButton()
    {
        if (ChooseEnemyCanvas.activeSelf)
        {
            ChooseEnemyCanvas.SetActive(false);
            BattleButtonCanvas.SetActive(true);
        }
        else if (InventoryCanvas.activeSelf)
        {
            InventoryCanvas.SetActive(false);
            BattleButtonCanvas.SetActive(true);
        }
    }
    
    
    
    
    
    
    
    //End Battle
    void LoseBattle()
    {
        SaveSystem.SavePlayer(player);
        PlayerPrefs.SetInt("LoadData",1);
        SceneManager.LoadScene("Game");
    }

    void WinBattle()
    {
        /*
        if (loot) Drop();
        Xp();
        */
        player.fightprogress[PlayerPrefs.GetInt("monsterID")] = true;

        SaveSystem.SavePlayer(player);
        Debug.Log("[Battle system END] : data have been saved ");
        PlayerPrefs.SetInt("LoadData",1);
        SceneManager.LoadScene("Game");
    }



    void changingStatePlayer()
    {
        if (!playerUnit.isalive && !ally1Unit.isalive && !ally2Unit.isalive)
        {
            state = BattleState.WIN;
            LoseBattle();
        }
        else
        {

            switch (state)
            {
                case BattleState.ENEMYTURN:
                    if (ally1Unit.isalive)
                    {
                        state = BattleState.PLAYERTURN1;
                    }
                    else if (ally2Unit.isalive)
                    {
                        state = BattleState.PLAYERTURN2;
                    }
                    else
                    {
                        state = BattleState.PLAYERTURN;
                    }

                    break;

                case BattleState.ENEMYTURN1:
                    if (ally2Unit.isalive)
                    {
                        state = BattleState.PLAYERTURN2;
                    }
                    else if (playerUnit.isalive)
                    {
                        state = BattleState.PLAYERTURN;
                    }
                    else
                    {
                        state = BattleState.PLAYERTURN1;
                    }

                    break;

                case BattleState.ENEMYTURN2:
                    if (ally2Unit.isalive)
                    {
                        state = BattleState.PLAYERTURN2;
                    }
                    else if (playerUnit.isalive)
                    {
                        state = BattleState.PLAYERTURN;
                    }
                    else
                    {
                        state = BattleState.PLAYERTURN1;
                    }

                    break;

            }
        }
    }

void changingStateEnemy(int selectEntity)
    {

        if (!enemyUnit.isalive && !enemy1Unit.isalive && !enemy2Unit.isalive)
        {
            state = BattleState.WIN;
            WinBattle();
        }
        else
        {
            switch (state)
            {
                case BattleState.PLAYERTURN:
                    if (enemyUnit.isalive)
                    {
                        state = BattleState.ENEMYTURN;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemyUnit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemyUnit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemyUnit));
                        }
                    }
                    else if (enemy1Unit.isalive)
                    {
                        state = BattleState.ENEMYTURN1;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemy1Unit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemy1Unit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemy1Unit));
                        }
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemyUnit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemyUnit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemyUnit));
                        }
                    }




                    break;
                case BattleState.PLAYERTURN1:
                    if (enemy1Unit.isalive)
                    {
                        state = BattleState.ENEMYTURN1;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemy1Unit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemy1Unit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemy1Unit));
                        }
                    }
                    else if (enemy2Unit.isalive)
                    {
                        state = BattleState.ENEMYTURN2;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemy2Unit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemy2Unit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemy2Unit));
                        }
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemyUnit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemyUnit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemyUnit));
                        }
                    }

                    break;

                case BattleState.PLAYERTURN2:
                    if (enemyUnit.isalive)
                    {
                        state = BattleState.ENEMYTURN;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemyUnit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemyUnit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemyUnit));
                        }
                    }
                    else if (enemy1Unit.isalive)
                    {
                        state = BattleState.ENEMYTURN1;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemy1Unit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemy1Unit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemy1Unit));
                        }
                    }
                    else
                    {
                        state = BattleState.ENEMYTURN2;
                        if (selectEntity == 1)
                        {
                            StartCoroutine(EnemyTurn(playerUnit, enemy2Unit));
                        }

                        if (selectEntity == 2)
                        {
                            StartCoroutine(EnemyTurn(ally1Unit, enemy2Unit));
                        }

                        if (selectEntity == 3)
                        {
                            StartCoroutine(EnemyTurn(ally2Unit, enemy2Unit));
                        }
                    }

                    break;
            }
        }
    }

    public void Drop ()
    {
        foreach (GameObject enemy in enemyList)
        {
            Random random = new Random();
            int alea = random.Next(0,10);
            Entity enemy2 = enemy.GetComponent<Entity>();
            if ( enemy2.lvl == 1 && alea <= 5)
            {
                playerPrefab.GetComponent<Player>().AddToInventory(enemy2.item_id);
            }
            if ( enemy2.lvl == 2 && alea <= 7)
            {
                playerPrefab.GetComponent<Player>().AddToInventory(enemy2.item_id);
            }
            else
            {
                playerPrefab.GetComponent<Player>().AddToInventory(enemy2.item_id);
            }
        }
    }
    
    /// tableau des xp
    public readonly int[] LVL_MOB_TO_XP = {3,4,5,7,8,9,10,11,12,13};

    public void Xp ()
    {
        int res = 0;
        
        foreach (GameObject enemy in enemyList)
        {
            res += LVL_MOB_TO_XP[enemy.GetComponent<Entity>().lvl-1];
        }
        playerPrefab.GetComponent<Entity>().GetXp(res);
    }
    

    //compteur de tour et execute les effets ou retire ceux qui sont fini

    public void ExecuteAllEffect(Entity unit)
    {
        foreach (var effect in unit.effectList)
        {
            if (effect.Item2 == nbTurn) unit.RemoveEffect(effect.Item1, unit);
            else EffectWithTurn(effect.Item1, unit);
        	nbTurn++;
		}	
    }

    //Potions a utiliser dans le combat en fonction du nombre de tour passé
    public void EffectWithTurn(string effect, Entity unit)
    {
        switch (effect)
        {
            case "Regeneration":
                RegenerationEffect(unit);
                break;
			case "Damage":
                DamageEffect(unit);
                break;
            case "Poison":
                PoisonEffect(unit);
                break;
            case "Heal":
                HealPotion(unit);
                break;
            
        }
    }
    
    
    public void HealPotion(Entity unit)
    {
        unit.GetHeal(5);
        changingStatePlayer();
    }
    
    public void RegenerationEffect(Entity unit)
    {
        unit.GetHeal(2);
    }
    
    public void LootEffect(Entity unit)
    {
        loot = unit.Loot();
    }

    public void PoisonEffect(Entity unit)
    {
        unit.GetHurt(2);
    }

    public void DamageEffect(Entity unit)
    {
        unit.GetHurt(10);
    }

    public void StrengtheningEffect(Entity unit)
    {
        unit.atk += 5;
    }
    
    public void WeaknessEffect(Entity unit)
    {
        unit.atk -= 5;
    }

    public void RemoveEffect()
    {
        throw new NotImplementedException();
    }



    public void HealPotionButton()
    {
        if (player.IsInInventory(0, 1))
        {
            player.RemoveFromInventory(0);
            switch (state)
            {
                case BattleState.PLAYERTURN:
                    playerUnit.AddEffect(("Heal", 1));
                    break;
                case BattleState.PLAYERTURN1:
                    ally1Unit.AddEffect(("Heal", 1));
                    break;
                case BattleState.PLAYERTURN2:
                    ally2Unit.AddEffect(("Heal", 1));
                    break;
            }
            
        }
        else
        {
            
        }
    }
    
    public void StrengthPotionButton()
    {
        if (player.IsInInventory(0, 1))
        {
            player.RemoveFromInventory(0);
        }
        else
        {
            
        }
    
    }
    
    public void LootPotionButton()
    {
        if (player.IsInInventory(0, 1))
        {
            player.RemoveFromInventory(0);
        }
        else
        {
            
        }
    }
    
    public void PoisonPotionButton()
    {
        if (player.IsInInventory(0, 1))
        {
            player.RemoveFromInventory(0);
        }
        else
        {
            
        }
    }
    
    public void RegenerationPotionButton()
    {
        if (player.IsInInventory(0, 1))
        {
            player.RemoveFromInventory(0);
        }
        else
        {
            
        }
    }
    
    public void DamagePotionButton()
    {
        if (player.IsInInventory(0, 1))
        {
            player.RemoveFromInventory(0);
        }
        else
        {
            
        }
    }


}


