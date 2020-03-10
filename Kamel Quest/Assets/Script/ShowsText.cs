using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowsText : MonoBehaviour
{
    public string[] sentences;
    public float speed = 0.2f;

    public bool restart;
    private TextMesh Txt;
    private string first_sentence;
    
    // Start is called before the first frame update
    void Start()
    {
        Txt = transform.GetChild(0).GetComponent<TextMesh>();
        first_sentence = sentences[0].Replace("$","\n");
        StartCoroutine(ShowsTxt());
    }
    // OnEnable is called every time this GameObject is Actived
    void OnEnable()
    {
        StartCoroutine(ShowsTxt());
    }

    IEnumerator ShowsTxt()
    {
        Txt.text = "";
        string tmp = first_sentence;
        int nb_char = first_sentence.Length;
        
        for (int i = 1; i <= nb_char; i++)
        {
            yield return new WaitForSeconds(speed);
            Txt.text = tmp.Substring(0, i);
        }
        
        
    }
}
