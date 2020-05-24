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



    // OnEnable is called every time the GO is active
    public void OnEnable()
    {   
		Debug.Log("Starting ShowsText");
		if (quest) SentencesList = transform.GetComponent<QuestGiver>().UpdateText();
		else SentencesList = transform.GetComponent<Dialogue>().SentencesList;
	    Index = 0;
        Anim = false;

        Txt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowsTxt(SentencesList[Index].Replace("$", "\n")));
		Index++;
    }

    void Update()
    {
	    // Needed to accept the quest with Y
	    if (quest && transform.GetComponent<Quest>().State == QuestState.ACCEPTED && !Anim && Input.GetKeyUp("y") || Input.GetKeyUp("n"))
			transform.GetComponent<Quest>().UpdateState();
	    // Press space to show the next sentence
	    else if (Input.GetKeyUp(KeyCode.Space) && !Anim)
        {
	        // Once all the sentence have been said, this will update the state of the quest
	        if (Index == SentencesList.Count)
	        {
		        if (quest) transform.GetComponent<Quest>().UpdateState();
		        else if (battle) transform.GetComponent<EnterBattle>().EnterBattlePlayer();
		        else gameObject.SetActive(false);
	        }
			// This display the current sentence
			else
			{
				string Sentence = SentencesList[Index].Replace("$", "\n");
            	StartCoroutine(ShowsTxt(Sentence));    
				Index++;     
			}
        }
	}
                                                                                                                             

	// Display the text
    IEnumerator ShowsTxt(string Str)
    {
	    Debug.Log("[ShowsText] ShowsTxt: Displaying sentence "+(Index+1)+"/"+SentencesList.Count+".");
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

