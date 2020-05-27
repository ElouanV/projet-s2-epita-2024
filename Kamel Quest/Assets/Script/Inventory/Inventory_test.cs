using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// Author : Elouan
/// <summary>
/// The main <c>Inventory_test</c> class.
/// Contains all methods for performing the player's inventory.
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
/// <term>AddToInventory</term>
/// <description>Add an item in the inventory</description>
/// </item>
/// <item>
/// <term>RemoveFromInventory</term>
/// <description>Remove an item in the inventory</description>
/// </item>
/// </list>
/// </summary>

public class Inventory_test : MonoBehaviour
{
    /// <summary>
    /// Contains all the variables used
    /// </summary>
    /// <remarks>
    /// Some of then are only use for test
    /// </remarks>
    [Header ("Automatically set")]
    public GameObject playercam;
    public GameObject inventoryCanvas;
    public GameObject shopPNJ;
    public GameObject pauseMenuCanvas;
    public bool pauseMenuOpen = false;
    public bool inventoryOpen = false;
    public bool shopOpen = false;
    public bool sellshopOpen = false;
    public GameObject itemList;
    
    [Header ("Button list")]
    public string inventoryButton = "Inventory";

    
    
    [Header("Inventory's Data")]
    public Transform inventorySlots;
    public Transform[] arrItemsSlot = new Transform[20];
    
    ///<summary>
    /// <para>Start is called before the first frame update</para>
    /// <para> This function set the playercam to the main camera and set inventorycanvas to the canvas inventory_panel </para>
    /// <returns>
    /// Return void
    /// </returns>
    ///</summary>
    void Start()
    {
        if (playercam == null)
        {
            playercam = GameObject.FindWithTag("MainCamera");
        }
        if (inventoryCanvas == null)
        {
            inventoryCanvas = GameObject.FindWithTag("Inventory");
        }
        if (shopPNJ == null)
        {
            shopPNJ = GameObject.FindWithTag("Shop");
        }
        if (itemList == null)
        {
            itemList = GameObject.FindWithTag("ItemList");
        }
        for (int i = 0; i < 20; i++)
        {
            arrItemsSlot[i] = inventorySlots.GetChild(i);
        }
        inventoryCanvas.SetActive(false);
    }

    ///<summary>
    ///<para> Update is called once per frame </para>
    ///<para> This function call the function ShowOrHideInventory() when the inventory key button is pressed down</para>
    ///<remarks>
    /// Currently, this function allowed us to test both functions AddToInventory and RemoveFromInventory by pressing a test button
    ///</remarks>
    ///</summary>
 
    void Update()
    {
        if (Input.GetButtonDown(inventoryButton))
        {
            ShowOrHideInventory();
        }
    
    }
    
    ///<summary>
    ///<para> This function add an item to the inventory </para>
    ///<para> 
    /// This function take two parametres : <param> ID </param> is the ID of the item which will be added, it will be used to find the inventory slots where the item is already present
    /// <param> counttoadd </param> is the number of item to add 
    /// We use the gameobject "ItemList" to find information of the item using his ID
    /// <remakrs> 
    /// If the number of item exced 64 in a slot, this function will create a new item in the next slot
    ///</remarks>
    ///<remarks>
    /// It update both player's inventory array 
    ///</remarks>
    ///<return>
    /// A bool to confirm is the addition has been done succesfully 
    ///</return>
    ///</summary>

    // Ajoute un élèment pas encore présent dans l'inventaire
    public bool AddToInventory(int ID, int counttoadd)
    {
        int i = 0;
        bool done = false;
        ItemSlots item = arrItemsSlot[0].GetComponent<ItemSlots>();
        while (i < 20 && !done && item.full)
        {
            //Vérifie si l'item est déja présent dans l'inventaire, si oui augmente item.count
            item = arrItemsSlot[i].GetComponent<ItemSlots>();
            if (item.itemID == ID && item.itemCount <64)
            {
                if (item.itemCount + counttoadd <= 64)
                {
                    item.itemCount += counttoadd;
                     //Player's inventory array
                    transform.GetComponent<Player>().inventoryCount[i] += counttoadd;
                    //
                    item.nbrItem.text = Convert.ToString(item.itemCount);
                    done = true;
                    counttoadd = 0;
                }
                else
                {
                    counttoadd = counttoadd - 64 + item.itemCount;
                    // Player's inventory array 
                    transform.GetComponent<Player>().inventoryCount[i] = 64;
                    //
                    item.itemCount = 64;
                    item.nbrItem.text = Convert.ToString(item.itemCount);
                }
            }
            i+=1;
        }
        if (i != 0)
        {
            i-=1;
        }
        if (!done && i <20)
        {
            Transform goitem = itemList.transform.GetChild(ID);
            Items myitem = goitem.GetComponent<Items>();
            //Créer un nouvel item
            item.textItem.text = myitem.itemName;
            item.itemID = ID;
            item.full = true;
            item.itemName = myitem.itemName;
            item.ChangeSprite(myitem.sprite);
            item.itemDescription = myitem.itemDescription;
            item.itemSprite = myitem.sprite;
            item.itemCount = counttoadd;
            //Player's inventory array 
            transform.GetComponent<Player>().inventoryCount[i] = counttoadd;
            transform.GetComponent<Player>().inventoryID[i] = ID;
            //
            item.nbrItem.text = Convert.ToString(counttoadd);
            done = true;
        }
        return done;
    }

    ///<summary>
    ///<para> This function remove an item from the inventory </para>
    ///<para> 
    /// This function take two parametres : <param> ID </param> is the ID of the item which will be removed, it will be used to find the inventory slots where the item is already present
    /// <param> count </param> is the number of item to remove
    ///<remakrs> 
    /// If the number of item drop to  in a slot, this function will remove item in another slots
    ///</remarks>
    ///<remarks>
    /// It update both player's inventory array 
    ///</remarks>
    ///<return>
    /// A bool to confirm is the deletion has been done succesfully 
    ///</return>
    ///</summary>
    public bool RemoveFromInventory(int ID, int count)
    {
        int i = 19;
        bool found = false;
        ItemSlots item = arrItemsSlot[i].GetComponent<ItemSlots>();
        while (i >= 0 && !found && count != 0)
        {
            item = arrItemsSlot[i].GetComponent<ItemSlots>();
            if(item.itemID == ID)
            {
                if (item.itemCount > count)
                // Si le montant a supprimer est inférieur au nombre d'item contenus dans le slot
                {
                    item.itemCount -= count;
                    //Player inventory array 
                    transform.GetComponent<Player>().inventoryCount[i] -= count;
                    //
                    item.nbrItem.text = Convert.ToString(item.itemCount);
                    count = 0;
                    found = true;
                }
                else
                // Si le montant a supprimer est supérieur ou égale nombre d'item contenus dans le slot
                {
                    // Delete item
                    // Pour rendre plus propre, créer une fonction dans item slots qui réinitialise toute les variables
                    item.itemCount = 0;
                    //Player inventory array
                    transform.GetComponent<Player>().inventoryID[i] = 0;
                    transform.GetComponent<Player>().inventoryCount[i] = 0;
                    //
                    item.nbrItem.text = Convert.ToString(item.itemCount);
                    item.RemoveSprite();
                    item.itemID = 0;
                    item.full = false;
                    item.itemName = "";
                    item.itemDescription = "";
                    count -= item.itemCount;
                }
            }
            i-=1;
        }
        if (count != 0)
        {
            // Si le nombre d'item présent dans l'inventaire n'était pas suffisant
            return false;
        }
        else
        {
            return true;
        }

    }



    ///<summary>
    ///<para> This function verify is there is enought item in the inventory </para>
    ///<para> 
    ///<param Name = "ID"> Is the item which we want to verify the number in the inventory </param>
    ///<param Name = "needed"> Is the number of item we need</param>
    ///<remarks>
    /// It use both player's inventory array 
    ///</remarks>
    ///<return>
    /// A true if there is enough object and false if not
    ///</return>
    ///</summary>
    public bool isInInventory(int ID, int needed)
    {
        int[] IDarray = transform.GetComponent<Player>().inventoryID;
        int[] countarray = transform.GetComponent<Player>().inventoryCount;
        int total = 0;
        for (int i = 0; i < 20; i++)
        {
            if (IDarray[i] == ID)
            {
				
                total += countarray[i];
            }
        }
        if (total >= needed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    ///<summary>
    ///This function allow to display or hide the inventory interface.
    ///<remakrs> 
    /// The mouse cursor is visvle only when the inventory is open.
    ///</remarks>
    ///</summary>
    public void ShowOrHideInventory ()
    {
        inventoryCanvas.SetActive(!inventoryOpen && !shopOpen && !sellshopOpen && !pauseMenuOpen); // active l'inventaire ou le desactive

            //Gestion du curseur
            // Rend le curseur visible si l'inventaire et ouvert, invisible si l'interface est fermé
        Cursor.visible = !inventoryOpen; 
        if (inventoryOpen||pauseMenuCanvas) 
            // Bloque le curseur hors de l'inventaire
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
            // Débloque le curseur dans l'inventaire
        {
            Cursor.lockState = CursorLockMode.None;
        }
            // inverse le booléen inventoryOpen
        inventoryOpen = (!inventoryOpen && !shopOpen && !sellshopOpen && !pauseMenuOpen); 
        shopPNJ.GetComponent<ShowShop>().inventoryOpen = inventoryOpen;
    }
}

