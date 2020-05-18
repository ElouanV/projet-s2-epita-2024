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
    Meeting, // Go to meet someone
    Killing, // Go to kill an ennemy
    Bringing // Bring an object to the PNG
}

public class Quest : MonoBehaviour
{
    public QuestType type;
    public QuestState State;
    public GameObject Target;
    public GameObject Player;
    
    public string title;
    public string desc;
    public int exp;
    public Items reward;

	public bool BackToPNJ;
	public bool anex;
	public GameObject scene;

    private bool completed;
	public void Completed(bool value)
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
			Debug.Log("TEST_ALPHA");
        }

        else if (State == QuestState.ACCEPTED)
        {
            if (Input.GetKeyUp("y"))
            {
                Debug.Log("[Quest] UpdateState: The quest '"+title+"' have been accepted.");

                // To add: Add quest to progression
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
            // To add: Give the reward

            State = QuestState.ENDED;
            Debug.Log("[Quest] UpdateState: The state of the quest '"+title+"' have been update to '"+State+"'.");
            gameObject.SetActive(false);
            if (anex) scene.SetActive(false);
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
			case QuestType.Bringing:
                if (completed) UpdateState();
                break;	
        }
    }

    // This function is call if the quest is completed
    public void CompletedQuest()
    {
        Debug.Log("[Quest] CompletedQuest: The quest '"+title+"' have been completed.");
        completed = true;
        if (State == QuestState.STARTED) UpdateState();
    }
}
 