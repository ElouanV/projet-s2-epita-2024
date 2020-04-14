using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState
{
	NONE,
	ACCEPTED,
   	STARTED,
	COMPLETED,
	ENDED
}

public class Quest: MonoBehaviour
{
	public QuestState State;
	public List<string> TextForNone;
	public List<string> TextForStarted; 
	public List<string> TextForCompleted;
	public List<string> TextForEnded;

	private List<string> YesOrNo;



    // Start is called before the first frame update
    void Start()
    {
		YesOrNo = new List<string> {"Acceptes-vous de me venir en aide ?$    	     [Y]- Yes   [N]- No"};
      
        State = QuestState.NONE;
    }
	
	public List<string> UpdateText()
	{
		List<string> current = new List<string> {};
		if (State == QuestState.NONE) current = TextForNone;
		else if (State == QuestState.ACCEPTED) current = YesOrNo;
		else if (State == QuestState.STARTED) current = TextForStarted;
		else if (State == QuestState.COMPLETED) current = TextForCompleted;
		else current = TextForEnded;
		return current;
	} 
}
