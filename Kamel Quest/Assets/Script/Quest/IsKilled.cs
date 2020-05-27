using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKilled : MonoBehaviour
{
    public GameObject QuestGiver;

    public void UpdateState()
    {
        QuestGiver.GetComponent<Quest>().State = QuestState.STARTED;
        QuestGiver.GetComponent<Quest>().CompletedQuest();
    }
}
