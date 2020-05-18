using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKilled : MonoBehaviour
{
    public GameObject QuestGiver;
    public bool IsQuest;

    public void UpdateState()
    {
        QuestGiver.GetComponent<Quest>().completed = true;
        QuestGiver.GetComponent<Quest>().UpdateState();
    }
}
