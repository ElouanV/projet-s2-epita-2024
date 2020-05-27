using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// Author : Julien
public class ShowsText : MonoBehaviour
{
    public float Speed = 0.02f;
	public bool quest;

	private List<string> SentencesList;
    private TextMeshProUGUI Txt;
    private int Index;
    private bool Anim;

    public bool battle;
    public bool TargetMeeting;



    /// <summary>
    /// Cette fonction permet d'initialiser les valeurs du texte d'un pnj
    /// </summary>
    public void OnEnable()
    {   
		if (quest) SentencesList = transform.GetComponent<QuestGiver>().UpdateText();
		else SentencesList = transform.GetComponent<Dialogue>().SentencesList;
	    Index = 0;
        Anim = false;

        Txt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowsTxt(SentencesList[Index].Replace("$", "\n")));
		Index++;
    }

	/// <summary>
    /// Cette fonction permet de détécter les interactions du joueur avec le système de Dialogue
    /// </summary>
    void Update()
    {
	    if (quest && transform.GetComponent<Quest>().State == QuestState.ACCEPTED && !Anim && Input.GetKeyUp("y") || Input.GetKeyUp("n"))
			transform.GetComponent<Quest>().UpdateState();
	    else if (Input.GetKeyUp(KeyCode.Space) && !Anim)
        {
	        // Once all the sentence have been said, this will update the state of the quest
	        if (Index == SentencesList.Count)
	        {
                if (battle) transform.parent.GetComponent<EnterBattle>().is_active = true;
		        else if (quest) transform.GetComponent<Quest>().UpdateState();
                else if (TargetMeeting) transform.parent.GetComponent<MeetingPNG>().questgiver.GetComponent<Quest>().CompletedQuest();
		       
		        else gameObject.SetActive(false);
	        }
			else
			{
				string Sentence = SentencesList[Index].Replace("$", "\n");
            	StartCoroutine(ShowsTxt(Sentence));    
				Index++;     
			}
        }
	}
                                                                                                                             

	/// <summary>
    /// Cette fonction permet d'afficher le texte dans la bulle lettre par lettre avec la possiblité de passer l'animation
    /// </summary>
    IEnumerator ShowsTxt(string Str)
    {
	    Anim = true;
        Txt.text = "";
        int Nb_Char = Str.Length;
        
        for (int i = 1; i <= Nb_Char; i++)
        {
	        // Allow to pass the animation
            if (Input.GetKeyDown(KeyCode.Space)) break;
            
            // Block the program until space is release
            yield return new WaitForSeconds(Speed);
            
            Txt.text = Str.Substring(0, i);
        }

        Txt.text = Str;
        while(Input.GetKey(KeyCode.Space)) yield return null;
        Anim = false;
    }
}

