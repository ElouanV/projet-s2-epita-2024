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
            CurrentAnex = 0;
            CurrentQuest = Prog[Current];
            InstallQuest();
        }
    }

    /// <summary>
    /// Cette fonction permet d'activer sur la scene Game la nouvelle quête principale
    /// </summary>
    public void InstallQuest()
    {
        CurrentQuest.SetActive(true);
    }

    /// <summary>
    /// Cette fonction permet d'activer toutes les quêtes annexes qui se sont débloquées en même temps que quête principale actuelle
    /// </summary>
    public void InstallQuestAnex()
    {
        GameObject Quest = ProgAnex[CurrentAnex];
        Quest.SetActive(true);
        Quest.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<Quest>().UpdateQuestID(CurrentAnex);

        ManageQquestAnnex();
        CurrentAnex++;
    }

    /// <summary>
    /// Cette fonction permet de trouver toutes les quêtes annexes d'activant en même temps que la quête principale actuelle
    /// </summary>
    public void ManageQquestAnnex()
    {
         if (ProgAnex.Count > 0) foreach (int i in ActiveQuest) if (Current == i) InstallQuestAnex();   
    }

    /// <summary>
    /// Cette fonction permet de supprimer une quête de la scene Game
    /// </summary>
    public void DeletedQuest()
    {
        Destroy(Prog[Current]);
    }
    /// <summary>
    /// Cette fonction permet de supprimer une quête annexe de la scene Game
    /// </summary>
    public void UpdateAnexCompleted(GameObject QuestAnex, int QuestID)
    {
        Destroy(QuestAnex);
        AnnexCompleted[QuestID] = true;
    }

    /// <summary>
    /// Cette fonction permet de charger les quêtes suivantes et de supprimer la quête principale complétée
    /// </summary>
    public void NextQuest()
    {
        DeletedQuest();
        Current++;
        prog_percent = (Current) * 100 / Prog.Capacity;
        if (Current < Prog.Capacity)
        {
            CurrentQuest = Prog[Current];
            InstallQuest();
            ManageQquestAnnex();
        }
    }
}
