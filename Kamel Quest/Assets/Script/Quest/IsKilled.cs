using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKilled : MonoBehaviour
{
    public GameObject QuestGiver;

    /// <summary>
    /// Cette fonction Compléter une quête de type Killing
    /// </summary>
    public void UpdateState()
    {
        QuestGiver.GetComponent<Quest>().State = QuestState.STARTED;
        QuestGiver.GetComponent<Quest>().CompletedQuest();
    }
}
