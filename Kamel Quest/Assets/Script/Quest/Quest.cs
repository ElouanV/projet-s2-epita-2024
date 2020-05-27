using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Authors : Julien
public enum QuestState
{
    NONE,
    ACCEPTED,
    DECLINED,
    STARTED,
    COMPLETED,
    ENDED
}

public enum QuestType
{
    Meeting, // Meet someone
    Killing, // Kill an ennemy
    Bringing, // Bring an object to the PNG
	Giving // Give an item from your inventory
}

public class Quest : MonoBehaviour
{
    public QuestType type;
    public QuestState State;
    public GameObject Target; // No use if quest state is Giving
    public GameObject Player;
    
    public string title;
    public string desc;
    
    public int money;
    public int exp;
    public int rewardID;
    public int rewardCount;

	private int questID;

	public bool BackToPNJ;
	public bool forced;
	public bool anex;
	public GameObject scene;

    private bool completed;
	
	public bool CompletedGet()
	{ 
		return completed;
	}

	public void CompletedSet(bool value)
	{
		completed = value;
	}
	/// <summary>
	/// Cette fonction permet d'actualiser l'état d'une quête et d'appliquer ses conséquences
	/// </summary>
    public void UpdateState()
    {
        if (State == QuestState.NONE)
        {
            State = QuestState.ACCEPTED;
            if (forced)
            {
                State = QuestState.STARTED;
                StartQuest(type);
            }
            transform.GetComponent<ShowsText>().OnEnable();
        }

        else if (State == QuestState.ACCEPTED)
        {
	        
            if (Input.GetKeyUp("y"))
            {
                State = QuestState.STARTED;
                transform.GetComponent<ShowsText>().OnEnable();

                StartQuest(type);
            }
            else if (Input.GetKeyUp("n"))
            {
	            State = QuestState.DECLINED;
	            transform.GetComponent<ShowsText>().OnEnable();
            }
        }

        else if (State == QuestState.STARTED)
        {
            if (completed)
            {
                completed = false;
                State = QuestState.COMPLETED;
                if (!BackToPNJ) UpdateState();
                else if (transform.parent.GetComponent<ShowsBubbleText>().is_trigger) transform.GetComponent<ShowsText>().OnEnable();
            }
            else gameObject.SetActive(false);
        }

        else if (State == QuestState.DECLINED)
        {
            State = QuestState.NONE;
            gameObject.SetActive(false);
        }

        else if (State == QuestState.COMPLETED)
        { 
	        if (rewardID != 0) Player.GetComponent<Inventory_test>().AddToInventory(rewardID, rewardCount);
	        Player.GetComponent<Player>().GetXp(exp);
	        Player.GetComponent<Player>().argent += money;
	        

            State = QuestState.ENDED;
            gameObject.SetActive(false);
            if (anex) Player.GetComponent<Progression>().UpdateAnexCompleted(scene, questID);
			else Player.GetComponent<Progression>().NextQuest();			
        }

        else if (State == QuestState.ENDED) gameObject.SetActive(false);
        
    }

	/// <summary>
	/// Cette fonction permet d'activer la cible d'une quête et elle vérifie si la quête à déjà était complétée
	/// </summary>
	public void StartQuest(QuestType type)
    {
        switch (type)
        {
            case QuestType.Meeting:
                Target.GetComponent<MeetingPNG>().is_active = true;
                break;
            case QuestType.Killing:
				if (completed) UpdateState();
				break;
			case QuestType.Bringing:
				Target.SetActive(true);
                if (completed) UpdateState();
                break;	
			case QuestType.Giving:
				completed = CompletedGivingQuest();
				if (completed) UpdateState();
                break;
        }
    }
	
	/// <summary>
	/// Cette fonction permet de compléter tout type de quête
	/// </summary>
	public void CompletedQuest()
    { 
        completed = true;
        if (State == QuestState.STARTED) UpdateState();
    }
	
	/// <summary>
	/// Cette fonction permet de vérifier si la quête giving est complétable et elle supprime l'item de l'inventaire
	/// </summary>
	public bool CompletedGivingQuest()
	{
		if (type == QuestType.Giving)                                                       
		{                                                                                   
			int ID = GetComponent<GivingExpected>().ID;                                      
			int Count = GetComponent<GivingExpected>().Count; 
			bool tmp = Player.GetComponent<Inventory_test>().isInInventory(ID, Count);  
  
			if (tmp) Player.GetComponent<Inventory_test>().RemoveFromInventory(ID, Count);
			return tmp;
		}   
		return false;                                                                                
	}

	/// <summary>
	/// Cette fonction permet de compléter la quête giving si les conditions sont réunis
	/// </summary>
	public bool CheckInventoryGiving()
	{
		if (State == QuestState.STARTED) completed = CompletedGivingQuest(); 
		if (completed) UpdateState();
		return completed;
	}
	/// <summary>
	/// Cette fonction permet de compléter une quête killing
	/// </summary>
	public bool CheckKilledEnemy()
	{
		//completed = !(Target.GetComponent<>().isalive);
		if (completed)
		{
			State = QuestState.STARTED;
			Target.GetComponent<IsKilled>().UpdateState();
		}
		return completed;	
	}

	public void UpdateQuestID(int ID)
	{
		questID = ID;
	}
}
 