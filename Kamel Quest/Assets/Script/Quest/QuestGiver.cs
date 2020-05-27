using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Authors : Julien
public class QuestGiver: MonoBehaviour
{
	public Quest quest;

	public List<string> TextForNone;
	public List<string> TextForStarted; 
	public List<string> TextForDeclined; 
	public List<string> TextForCompleted;
	public List<string> TextForEnded;

	private List<string> YesOrNo;



	// Start is called before the first frame update
    void Start()
    {
	    YesOrNo = new List<string> {"Acceptes-vous cette quête ?$$                             [Y]- Yes		   [N]- No"};
    }
	// Update what the PNG say depending of the quest state
	public List<string> UpdateText()
	{
		if (quest.type == QuestType.Giving) transform.GetComponent<Quest>().CheckInventoryGiving();
		//else if (quest.type == QuestType.Killing) transform.GetComponent<Quest>().CheckKilledEnemy();
		List<string> current = new List<string> {};
		if (quest.State == QuestState.NONE) current = TextForNone;
		else if (quest.State == QuestState.ACCEPTED) current = YesOrNo;
		else if (quest.State == QuestState.STARTED) current = TextForStarted;
		else if (quest.State == QuestState.DECLINED) current = TextForDeclined;
		else if (quest.State == QuestState.COMPLETED) current = TextForCompleted;
		else current = TextForEnded;
		return current;
	}
}
