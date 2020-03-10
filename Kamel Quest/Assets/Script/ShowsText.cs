using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowsText : MonoBehaviour
{
    public string[] sentencesArr;
    public float speed = 0.02f;
    public GameObject thisGO;

    private TextMeshProUGUI Txt;
    private int index;
    private bool anim;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        anim = false;
        Txt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowsTxt(sentencesArr[index].Replace("$", "\n")));
        index++;
    }

// OnEnable is called every time this GameObject is Actived
    void OnEnable()
    {
        Start();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !anim && index < sentencesArr.Length)
        {
            string sentence = sentencesArr[index].Replace("$", "\n");
            StartCoroutine(ShowsTxt(sentence));
            index++;
            
        }
        else if (Input.GetKeyUp(KeyCode.Space) && index == sentencesArr.Length && !anim)
        {
            thisGO.SetActive(false);
        }
    }

    IEnumerator ShowsTxt(string str)
    {
        anim = true;
        Txt.text = "";
        int nb_char = str.Length;
        
        for (int i = 1; i <= nb_char; i++)
        {
            if (Input.GetKeyDown(KeyCode.Space)) break;
            yield return new WaitForSeconds(speed);
            Txt.text = str.Substring(0, i);
        }

        Txt.text = str;
        while(Input.GetKey(KeyCode.Space))
        {
            yield return null;
        }
        anim = false;
    }
}
