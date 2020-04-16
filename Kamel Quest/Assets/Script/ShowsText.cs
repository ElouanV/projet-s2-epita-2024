using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowsText : MonoBehaviour
{
    public float Speed = 0.02f;

	private List<string> SentencesList;
    private TextMeshProUGUI Txt;
    private int Index;
    private bool Anim;



    // Start is called before the first frame update
    void Start()
    {
		SentencesList = transform.GetComponent<QuestGiver>().UpdateText();
		
        Index = 0;
        Anim = false;

        Txt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowsTxt(SentencesList[Index].Replace("$", "\n")));
		Index++;
    }

	// OnEnable is called every time this GameObject is Actived
    public void OnEnable()
    {
        Start();
    }

    void Update()
    {
		if (transform.GetComponent<Quest>().State == QuestState.ACCEPTED && !Anim) transform.GetComponent<Quest>().UpdateState();
        else if (Input.GetKeyUp(KeyCode.Space) && !Anim)
        {
			if (Index == SentencesList.Count) transform.GetComponent<Quest>().UpdateState();
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
        Anim = true;
        Txt.text = "";
        int Nb_Char = Str.Length;
        
        for (int i = 1; i <= Nb_Char; i++)
        {
            if (Input.GetKeyDown(KeyCode.Space)) break;
            yield return new WaitForSeconds(Speed);
            Txt.text = Str.Substring(0, i);
        }

        Txt.text = Str;
        while(Input.GetKey(KeyCode.Space)) yield return null;
        Anim = false;
    }
}

