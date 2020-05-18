using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public List<GameObject> Prog;
    public GameObject CurrentQuest;
    public int Nb_Quest;
    public int Current;
    public int prog_percent;

    public List<GameObject> ProgAnex;
    public GameObject CurrentQuestAnex;

    // Start is called before the first frame update
    void Start()
    {
        prog_percent = 0;
        Nb_Quest = Prog.Count;
        Current = 0;
        CurrentQuest = Prog[Current];
        InstallQuest();
    }

    public void InstallQuest()
    {
        CurrentQuest.SetActive(true);
    }

    public void DeletedQuest()
    {
        CurrentQuest.SetActive(false);
    }

    public void NextQuest()
    {
        DeletedQuest();
        Current++;
        prog_percent = (Current) * 100 / Prog.Count;
        CurrentQuest = Prog[Current];
        InstallQuest();
    }
}
