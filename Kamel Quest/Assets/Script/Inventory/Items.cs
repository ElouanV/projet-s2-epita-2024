using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author : Elouan
/// <summary>
/// The main <c>Items</c> class.
/// Mother class which class Usable, Stuff, Others herit.
/// <para> Class : </para>
/// <list type="bullet">
/// <item>
/// <term>Usable</term>
/// <description> Are all item which can be used and have instant effect, like potion, their type is 0</description>
/// </item>
/// <item>
/// <term>Stuff</term>
/// <description>Are all item which can be equiped on player, they boost player's statistics. Their item type is 1</description>
/// </item>
/// <item>
/// <term>Other</term>
/// <description>Are other item, which are unusable and arent stuff, relic of a mosnter for exemple. Their type is 2</description>
/// </item>
/// </list>
/// </summary>
public class Items : MonoBehaviour
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int type;
    public Sprite sprite;
    public int lvl;
}
