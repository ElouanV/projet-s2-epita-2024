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
    public BattleState state;
    public Text dialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
    }

    public void SetupBattle() //faire spawn les entités au bonne endroit et mettre les UI a jour
    {
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
