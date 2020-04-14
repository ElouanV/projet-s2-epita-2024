﻿using System.Collections;
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
	private bool completed;


    // Start is called before the first frame update
    void Start()
    {
		SentencesList = transform.GetComponent<Quest>().UpdateText();
		
		completed = false;
        Index = 0;
        Anim = false;

        Txt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowsTxt(SentencesList[Index].Replace("$", "\n")));
		Index++;
    }

	// OnEnable is called every time this GameObject is Actived
    void OnEnable()
    {
        Start();
    }

    void Update()
    {
		if (transform.GetComponent<Quest>().State == QuestState.ACCEPTED) UpdateState();
        else if (Input.GetKeyUp(KeyCode.Space) && !Anim)
        {
			if (Index < SentencesList.Count)
			{
            	string Sentence = SentencesList[Index].Replace("$", "\n");
            	StartCoroutine(ShowsTxt(Sentence));    
				Index++;     
			}
			else UpdateState();
        }
	}
                                                                                                                             
	void UpdateState()
	{
		if (transform.GetComponent<Quest>().State == QuestState.NONE) 
		{                     
            transform.GetComponent<Quest>().State = QuestState.ACCEPTED;                     
            transform.GetComponent<Quest>().UpdateText();                                   
            Start();  
		}                                                                      
                                                                                                
        else if (transform.GetComponent<Quest>().State == QuestState.ACCEPTED)                  
        {                                                                                       
        	if (Input.GetKeyUp("y"))  
			{                                                          
        		transform.GetComponent<Quest>().State = QuestState.STARTED;                     
        		transform.GetComponent<Quest>().UpdateText();                                   
        		Start();     
			}
			else if (Input.GetKeyUp("n"))
			{
				transform.GetComponent<Quest>().State = QuestState.STARTED; 
                transform.GetComponent<Quest>().UpdateText();               
                Start();      
          	}                                                                                                   
        }                                                                                       
                                                                                                
        else if (transform.GetComponent<Quest>().State == QuestState.STARTED)                   
        {     
			gameObject.SetActive(false);                                                                                  
        	if (completed)  
			{                                                                    
        		transform.GetComponent<Quest>().State = QuestState.COMPLETED;                   
        		transform.GetComponent<Quest>().UpdateText();   
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

