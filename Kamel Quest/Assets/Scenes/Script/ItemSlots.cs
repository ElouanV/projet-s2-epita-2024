using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    public Text textItem;
    public GameObject textDisplay;
    [Header("Item's Data")]
    public string itemType;
    public string itemID;
    public Sprite itemSprite;
    public string itemDescription;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = itemSprite;
        textItem.text = itemDescription;
    }

    void OnEnable()
    {
        DisableText();
    }
    public void ActiveText ()
    {
        textDisplay.SetActive(true);
    }
    public void DisableText ()
    {
        textDisplay.SetActive(false);   
    }

}
