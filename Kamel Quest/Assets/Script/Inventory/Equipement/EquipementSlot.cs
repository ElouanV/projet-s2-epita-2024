using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Author : Elouan
///<system>
/// The main <c>EquipementSlot</c> class.
/// Contains all methods for performing each slot of equipment inventory
/// <para> The equipment inventory is composed by 3 inventorySlots, one for sword, one for shield and one for armor </para>
/// <list type="bullet">
/// <item>
/// <term>Upgrade</term>
/// <description>Upgrade the item in the slot</description>
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
public class EquipementSlot : MonoBehaviour
{
    [Header("Sprite")]
    public Sprite itemSpriteLvl1;
    public Sprite itemSpriteLvl2;
    public Sprite itemSpriteLvl3;
    
    [Header("Text")]
    public Text itemText;

    [Header("Lvl")]
    public int Lvl;

    ///<summary>
    /// <para>Start is called before the first frame update</para>
    /// <para> Set sprite, slot lvl, and text </para>
    /// <returns>
    /// Return void
    /// </returns>
    ///</summary>
    void Start()
    {
        Lvl = 1;
        GetComponent<Image>().sprite = itemSpriteLvl1;
        itemText.text = "I";
    }


    ///<summary>
    /// This function is used to upgrade the item in the slot. It change the sprite, the text and the lvl of the slot.
    ///</summary>
    public void Upgrade()
    {
        switch (Lvl)
        {
            case 1:
            {
                ChangeSprite(itemSpriteLvl2);
                itemText.text = "II";
                Lvl +=1;
                break;
            }
            case 2:
            {
                ChangeSprite(itemSpriteLvl3);
                itemText.text = "III";
                Lvl += 1;
                break;
            }
            default:
            {
                break;
            }
        }
    }
    ///<summary>
    /// This function is only use to change the sprite by the given sprite
    ///</summary>
    public void ChangeSprite(Sprite newSprite)
    {
        GetComponent<Image>().sprite = newSprite;
    }
}
