using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
// Author : Elouan
///<system>
/// The main <c>KeySlot</c> class.
/// Contains all methods for performing each slot of equipment inventory
/// <para> The equipment inventory is composed by 1 inventorySlots, which contain the number of key possesse by the player</para>
/// <list type="bullet">
/// <item>
/// <term>AddKey</term>
/// <description>Add a key to the inventory</description>
/// </item>
/// <item>
/// <term>ChangeSprite</term>
/// <description>Change the sprite of the slot</description>
/// </item>
/// <item>
/// <item>
/// <term>Update</term>
/// <description>Temporary function to test this script, call every frame</description>
/// </item>
/// </list>
///<remarks>
/// This script is similary to the script ItemSlots
///</remarks>
///</system>
public class KeySlot : MonoBehaviour
{
    [Header("Sprite")]
    public Sprite keySprite;

    [Header("Number Of Key possess")]
    public int nbrKey;
    
    [Header("Text")]
    public Text keyText;
    public string textKey;
    
    ///<summary>
    /// <para>Start is called before the first frame update</para>
    /// <para> Set sprite, number of key, and text </para>
    /// <returns>
    /// Return void
    /// </returns>
    ///</summary>
    void Start()
    {
        nbrKey = 0;
        textKey = Convert.ToString(nbrKey);
        GetComponent<Image>().sprite = keySprite;
        keyText.text = textKey;
    }

    ///<summary>
    /// This function is used to increment the key counter and display it on the slot.
    ///</summary>
    public void AddKey()
    {
        if (nbrKey < 3)
        {
            nbrKey +=1;
            textKey = Convert.ToString(nbrKey);
            keyText.text = textKey;
        }
    }
}
