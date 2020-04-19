using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{

    public Text textItem;
    public GameObject textDisplay;
    [Header("Item's Data")]
    public bool full;
    public string itemName;
    public int itemID;
    public Sprite itemSprite;
    public string itemDescription;
    public int itemCount;
    // Start is called before the first frame update
    void Start()
    {
        if (itemCount == 0)
        {
            full = false;
        }
        else
        {
            full = true;
        }
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

    public void AddItem()
    {
        itemCount +=1;
    }
    
    public void UseItem()
    {
        itemCount -=1;

    }

    public void ChangeSprite(Sprite newsprite)
    {

        GetComponent<Image>().sprite = newsprite;
    }
    public void RemoveSprite()
    {
        Debug.Log(" Doit supprimer le sprite du slot");
    }

}
