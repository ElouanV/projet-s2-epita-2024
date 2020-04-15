using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : Quest
{
    public GameObject Pnj;

    public QuestState State;
    // Start is called before the first frame update
    void Start()
    {
        State = Quest.QuestState.STARTED;
    }

    // Update is called once per frame
    void OnTriggerEnter2D()
    {
        if (Pnj.GetComponent<Quest>().State == QuestState.STARTED) State == QuestState.COMPLETED;
    }
}
