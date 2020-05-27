using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progression : MonoBehaviour
{
    public List<GameObject> Prog;
    private GameObject CurrentQuest;
    private int Nb_Quest;
    public int Current;
    

    public List<GameObject> ProgAnex;
    private int CurrentAnex;
    public int[] ActiveQuest;   // = new int[]{0,1, 2, 2};
    public bool[] AnnexCompleted;
    
    public int prog_percent;


    public int CurrentGetSet
    {
        get => Current; 
        set => Current = value;
    }
    public GameObject CurrentQuestGetSet
    {
        get => CurrentQuest;
        set => CurrentQuest = value;
    }
    // Start is called before the first frame update
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name  != "FightScene")
        {
            AnnexCompleted = new bool[ProgAnex.Count];
            prog_percent = 0;
            Nb_Quest = Prog.Capacity;
            Current = 0;
            Debug.Log("Current =  0");
            CurrentAnex = 0;
            CurrentQuest = Prog[Current];
            InstallQuest();
            ManageQuestAnex();
        }
    }

    public void InstallQuest()
    {
        CurrentQuest.SetActive(true);
    }

    public void InstallQuestAnex()
    {
        GameObject Quest = ProgAnex[CurrentAnex];
        Quest.SetActive(true);
        Quest.transform.GetChild(0).GetChild(1).GetComponent<Quest>().UpdateQuestID(CurrentAnex);
        
        CurrentAnex++;
    }

    public void ManageQuestAnex()
    {
        if (ProgAnex.Count > 0) foreach (int i in ActiveQuest) if (Current == i) InstallQuestAnex();
    }

    public void DeletedQuest()
    {
        Debug.Log("[Destroy] : PIFIOUFF §" + Current);
        Destroy(Prog[Current]);
    }

    public void UpdateAnexCompleted(GameObject QuestAnex, int QuestID)
    {
        Destroy(QuestAnex);
        AnnexCompleted[QuestID] = true;
    }

    public void NextQuest()
    {
        DeletedQuest();
        Current++;
        Debug.Log("[NextQuest] : Current :" + Current);
        Debug.Log("[NextQuest] : Nbr_quest :" + Prog.Capacity);
        prog_percent = (Current) * 100 / Prog.Capacity;
        if (Current < Prog.Capacity)
        {
            Debug.Log("Installiing the next main quest");
            CurrentQuest = Prog[Current];

            InstallQuest();
            ManageQuestAnex();
        }
    }
}
