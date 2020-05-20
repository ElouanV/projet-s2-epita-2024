using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public List<GameObject> Prog;
    private GameObject CurrentQuest;
    private int Nb_Quest;
    private int Current;
    

    public List<GameObject> ProgAnex;
    private int CurrentAnex;
    private int[] ActiveQuest = new int[]{1};
    
    public int prog_percent;

    // Start is called before the first frame update
    void Start()
    {
        prog_percent = 0;
        Nb_Quest = Prog.Count;
        Current = 0;
        CurrentAnex = 0;
        CurrentQuest = Prog[Current];
        InstallQuest();
    }

    public void InstallQuest()
    {
        CurrentQuest.SetActive(true);
    }

    public void InstallQuestAnex()
    {
        ProgAnex[CurrentAnex].SetActive(true);
        CurrentAnex++;
    }

    public void DeletedQuest()
    {
        Destroy(CurrentQuest);
    }

    public void NextQuest()
    {
        DeletedQuest();
        Current++;
        prog_percent = (Current) * 100 / Prog.Count;
        if (Current < Nb_Quest)
        {
            CurrentQuest = Prog[Current];

            InstallQuest();
            foreach (int i in ActiveQuest) if (Current == i) InstallQuestAnex();
        }
    }
}
