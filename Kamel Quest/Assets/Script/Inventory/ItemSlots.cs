using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// Author : Elouan
/// <summary>
/// The main <c>ItemSlots</c> class.
/// Contains all methods for performing each slot of inventory
/// <para> The inventory is composed by 20 inventorySlots, each slot can countain 64 items with the same ID </para>
/// <list type="bullet">
/// <item>
/// <term>Start</term>
/// <description>Is called before the first frame update</description>
/// </item>
/// <item>
/// <term>Update</term>
/// <description>Is called once per frame</description>
/// </item>
/// <item>
/// <term>OnEnable, ActiveText, Disable Text</term>
/// <description>Are use to active or disable name bubble text when the mouse is on the slot</description>
/// </item>
/// <item>
/// <term>Change Sprite</term>
/// <description>Change the sprite in a slot and make it opac</description>
/// </item>
/// <item>
/// <term>Remove Sprite</term>
/// <description>Set the current sprite invisble</description>
/// </item>
/// </list>
/// </summary>
public class ItemSlots : MonoBehaviour
{

    public Text textItem;
    public GameObject textDisplay;
    public Text nbrItem;
    public GameObject nrbDisplay; 
    [Header("Item's Data")]
    public bool full;
    public string itemName;
    public int itemID;
    public Sprite itemSprite;
    public string itemDescription;
    public int itemCount;
    ///<summary>
    /// <para>Start is called before the first frame update</para>
    /// <para> Set sprite invisible, full at true is count > 0, and set text </para>
    /// <returns>
    /// Return void
    /// </returns>
    ///</summary>
    void Start()
    {
        full = (itemCount != 0);
        GetComponent<Image>().color = new Color(1f,1f,1f,0f);
        GetComponent<Image>().sprite = itemSprite;
        textItem.text = itemName;
        nbrItem.text = Convert.ToString(itemCount);
    }
    ///<summary>
    /// This 3 function are only use to set active or not the text object which contain item name.
    ///</summary>
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
    ///<summary>
    /// ChangeSprite set the Image srite to the srpite given, and set color to "1f" and make is visible
    ///</summary>
    public void ChangeSprite(Sprite newsprite)
    {
        GetComponent<Image>().sprite = newsprite;
        GetComponent<Image>().color = new Color(1f,1f,1f,1f); //Rends le sprite opaque
    }
    ///<summary>
    /// RemoveSprite set the Image color to "0f" and make is visible, but it doesn't work yet.
    ///</summary>
    public void RemoveSprite()
    {
        GetComponent<Image>().color = new Color(1f,1f,1f,0f); // Rends le sprite transparant (Opacité à 0%)
    }

}
