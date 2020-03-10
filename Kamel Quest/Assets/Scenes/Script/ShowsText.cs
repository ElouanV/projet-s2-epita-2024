using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowsText : MonoBehaviour
{
    public string[] sentencesArr;
    public float speed = 0.2f;
    public float timeForRead = 10f;
    public bool scroll;
    public bool restart;
    private TextMesh Txt;
    private string first_sentence;

    // Start is called before the first frame update
    void Start()
    {
        Txt = transform.GetChild(0).GetComponent<TextMesh>();
        string sentence = sentencesArr[0].Replace("$", "\n");
        if (scroll) StartCoroutine(ShowsTxt(sentence));      
        else Txt.text = sentence;
    }

// OnEnable is called every time this GameObject is Actived
    void OnEnable()
    {
        Start();
    }

    void Upddate()
    {
     
    }

    IEnumerator ShowsTxt(string sentence)
    {
        Txt.text = "";
        int nb_char = sentence.Length;
        
        for (int i = 1; i <= nb_char; i++)
        {
            if (Input.GetKeyDown(KeyCode.Space)) break;
            yield return new WaitForSeconds(speed);
            Txt.text = sentence.Substring(0, i);
        }
        Txt.text = sentence;
        
    }
}
