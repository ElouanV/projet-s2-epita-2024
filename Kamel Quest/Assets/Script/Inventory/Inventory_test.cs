﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject invetoryCanvas;
    public bool inventoryOpen = false;
    
    [Header ("Button list")]
    public string inventoryButton;

    [Header("For Test")]
    public string testButton;
    public string test2Button = "Test2";
    public string test3Button = "Test3";
    public Sprite healPotionSprite;
    public Sprite monsterRelicSprite;
    
    [Header("Inventory's Data")]
    
    public Transform inventorySlots;

    [Header("ItemSlot")]
    public GameObject[] arrItemsSlot = new GameObject[20];
    
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

        if (invetoryCanvas == null)
        {
            invetoryCanvas = GameObject.Find("Inventory_Panel");
        }
        invetoryCanvas.SetActive(false);
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
       if (Input.GetButtonDown(testButton))
        {
            AddToInventory(1,"HealPotion",1,"Ceci est un test, en voici la déscription",healPotionSprite);
        }
        if (Input.GetButtonDown(test2Button))
        {
           AddToInventory(2,"MonsterLoot",1,"You've earn it by killing a monster",monsterRelicSprite);
        }
        if  (Input.GetButtonDown(test3Button))
        {
            RemoveFromInventory(1,1);
        }
    }
    
    ///<summary>
    ///<para> This function add an item to the inventory </para>
    ///<para> 
    /// This function take five parametres : <param> ID </param> is the ID of the item which will be added, it will be used to find the inventory slots where the item is already present
    /// <param> name </param> is a string, the name of the item
    /// <param> counttoadd </param> is the number of item to add 
    /// <param> description </param> is the description of the item, will be only use if we have to add item in an empty slot
    /// <param> sprite </param> is the sprite of the item, will be only use if we have to add item in an empty slot
    ///<remakrs> 
    /// If the number of item exced 64 in a slot, this function will create a new item in the next slot
    ///</remarks>
    ///</summary>

    // Ajoute un élèment pas encore présent dans l'inventaire
    // Debug.Log pour tester la fonction
    // Amélioration : Créer une limite de stack pour éviter de faire exploser le PC du jury à la soutenance finale
    // A faire : Si l'inventaire est plein, doit retourner faux afin que dans la boutique, un achat ne puisse pas être fait si l'inventaire est plein
    public void AddToInventory(int ID, string name, int counttoadd, string description, Sprite sprite)
    {
        int i = 0;
        bool done = false;
        ItemSlots item = arrItemsSlot[0].GetComponent<ItemSlots>();
        Debug.Log("Test : Le script arrive jusqu'au GetComponent");
        while (i < 20 && !done && item.full)
        {
            //Vérifie si l'item est déja présent dans l'inventaire, si oui augmente item.count
            Debug.Log("Test : Le script arrive entre dans la boucle à l'index " + i);
            item = arrItemsSlot[i].GetComponent<ItemSlots>();
            Debug.Log("Test : Le script compare les ID d'item " + item.itemID + " celui en paramètre" + ID);
            if (item.itemID == ID && item.itemCount <64)
            {
                if (item.itemCount + counttoadd <= 64)
                {
                    item.itemCount += counttoadd;
                    done = true;
                    counttoadd = 0;
                }
                else
                {
                    counttoadd = counttoadd - 64 + item.itemCount;
                    item.itemCount = 64;
                }
                Debug.Log("Test : Le script ajoute l'item existant");
            }
            i+=1;
        }
        Debug.Log("Test : Le script arrive sort dans la boucle");
        if (!done)
        {
            //Créer un nouvel item
            Debug.Log("Test : Le script créer un nouvel item");
            item.itemID = ID;
            item.full = true;
            item.itemName = name;
            item.ChangeSprite(sprite);
            item.itemDescription = description;
            item.itemSprite = sprite;
            item.itemCount = counttoadd;
        }
    }

    // Supprime count fois l'item de l'inventaire
    // Amélioration : La fonction devras renvoyer un booléen qui permettra de savoir si la suppresion à bien été effectuer, pour une vente par exemple
    void RemoveFromInventory(int ID,int count)
    {
        int i =0;
        bool found = false;
        ItemSlots item = arrItemsSlot[i].GetComponent<ItemSlots>();
        while (i < 20 && !found && count != 0)
        {
            item = arrItemsSlot[i].GetComponent<ItemSlots>();
            if(item.itemID == ID)
            {
                if (item.itemCount > count)
                // Si le montant a supprimer est inférieur au nombre d'item contenus dans le slot
                {
                    item.itemCount -= count;
                    count = 0;
                    found = true;
                }
                else
                // Si le montant a supprimer est supérieur ou égale nombre d'item contenus dans le slot
                {
                    // Delete item
                    // Pour rendre plus propre, créer une fonction dans item slots qui réinitialise toute les variables
                    item.itemCount = 0;
                    item.RemoveSprite();
                    item.itemID = 0;
                    item.full = false;
                    item.itemName = "";
                    item.itemDescription = "";
                    count -= item.itemCount;
                }
            }
            i+=1;
        }
        if (count != 0)
        {
            // Si le nombre d'item présent dans l'inventaire n'était pas suffisant
            Debug.Log("You ask to remove to much time the item or you try to remove an item which was'nt in the inventory."
            +"All counter of this item have been set to 0 and items which correcpund to the enter ID have been removed");
        }
    }


    // affiche / enleve l'inventaire sur l'écran, ajoute le curseur de la souris si besoin
    void ShowOrHideInventory ()
    {
        invetoryCanvas.SetActive(!inventoryOpen); // active l'inventaire ou le desactive

        //Gestion du curseur
        // Rend le curseur visible si l'inventaire et ouvert, invisible si l'interface est fermé
        Cursor.visible = !inventoryOpen; 
        if (inventoryOpen) 
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
        inventoryOpen = !inventoryOpen;
    }


    // A faire ?
    // ClearInventory() permtrais de supprimer tous les items de l'inventaire, peut être utile dans certains cas ?
    // Alléger les fonctions ci-dessus en 
}
