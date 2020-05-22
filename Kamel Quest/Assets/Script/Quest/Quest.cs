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
    public int exp;
    public int rewardID;
    public int rewardCount;

	public bool BackToPNJ;
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

    // This willupdate the state of the quest if it's needed
    public void UpdateState()
    {
        if (State == QuestState.NONE)
        {
            State = QuestState.ACCEPTED;
            Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");
            transform.GetComponent<ShowsText>().OnEnable();
        }

        else if (State == QuestState.ACCEPTED)
        {
            if (Input.GetKeyUp("y"))
            {
                Debug.Log("[Quest] UpdateState: The quest '"+title+"' have been accepted.");

                State = QuestState.STARTED;
                Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");
                transform.GetComponent<ShowsText>().OnEnable();

                StartQuest(type);
            }
            else if (Input.GetKeyUp("n"))
            {
                Debug.Log("[Quest] UpdateState: The quest '"+title+"' have been declined.");

                State = QuestState.DECLINED;
                Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");
                transform.GetComponent<ShowsText>().OnEnable();
            }
        }

        else if (State == QuestState.STARTED)
        {
            if (completed)
            {
                completed = false;
                State = QuestState.COMPLETED;
                if (!BackToPNJ)
                {
                    UpdateState();
                    Player.GetComponent<Progression>().NextQuest();
                    Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");                }
                else if (transform.parent.parent.GetComponent<ShowsBubbleText>().is_trigger) transform.GetComponent<ShowsText>().OnEnable();
                Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");
            }
            else gameObject.SetActive(false);
        }

        else if (State == QuestState.DECLINED)
        {
            State = QuestState.NONE;
            Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");
            gameObject.SetActive(false);
        }

        else if (State == QuestState.COMPLETED)
        {
	        Player.GetComponent<Inventory_test>().AddToInventory(rewardID, rewardCount);

            State = QuestState.ENDED;
            Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");
            gameObject.SetActive(false);
            if (anex) Destroy(scene);
			else Player.GetComponent<Progression>().NextQuest();
			
        }

        else if (State == QuestState.ENDED) gameObject.SetActive(false);
        
    }

    // This will active the target of the quest depending of the type
    public void StartQuest(QuestType type)
    {
        switch (type)
        {
            case QuestType.Meeting:
                Target.GetComponent<MeetingPNG>().is_active = true;
                break;
            case QuestType.Killing:
				Target.GetComponent<EnterBattle>().is_active = true;
				if (completed) UpdateState();
				break;
			case QuestType.Bringing:
                if (completed) UpdateState();
                break;	
			case QuestType.Giving:
				completed = CompletedGivingQuest();
				if (completed) UpdateState();
                break;
        }
    }

    // This function is call if the quest is completed
    public void CompletedQuest()
    { 
        completed = true;
		if (type == QuestType.Bringing) Player.GetComponent<Inventory_test>().RemoveFromInventory(Target.GetComponent<Items>().itemID , 1);
		Debug.Log("[Quest] CompletedQuest: The quest '"+title+"' have been completed.");
        if (State == QuestState.STARTED) UpdateState();
    }

	public bool CompletedGivingQuest()
	{
		if (type == QuestType.Giving)                                                       
		{                                                                                   
			int ID = GetComponent<GivingExpected>().ID;                                      
			int Count = GetComponent<GivingExpected>().Count; 
			Debug.Log("Looking for item '"+ID+"' in Count : "+Count+".");           
			bool tmp = Player.GetComponent<Inventory_test>().isInInventory(ID, Count);  
			Debug.Log("isInInventory return "+tmp);           
  
			if (tmp)
			{
				Debug.Log("Items Found");
				Debug.Log(Count+" item '"+ID+"' have been removed from your inventory");
				Player.GetComponent<Inventory_test>().RemoveFromInventory(ID, Count);
			}
			else Debug.Log("Items not Found"); 
			return tmp;
		}   
		return false;                                                                                
	}

	public bool CheckInventoryGiving()
	{
		if (State == QuestState.STARTED) completed = CompletedGivingQuest(); 
		if (completed) UpdateState();
		return completed;
	}
}
 