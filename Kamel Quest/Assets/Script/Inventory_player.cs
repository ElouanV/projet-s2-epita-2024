using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_player : MonoBehaviour
{
    [Header ("En cours de développement")]
    public List<Items> inventory = new List<Items>(); // création d'inventaire sous forme de liste
   
    
    public GameObject playercam;

    //FOR TEST
    
    

    [Header ("Button list")]
    public string inventoryButton;
    public string testButton;

    
    [Header("Inventory's Data")]
    public GameObject invetoryCanvas;
    [HideInInspector] public bool inventoryOpen = false;

    public Transform inventorySlots;
    public int slotCount = 20; // Inventory's size,, limit to 20
    [Header("ItemPrefabs")]
    public Transform itemPrefab;
    public Transform itemPrebHealPotion;
    
    


    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(inventoryButton))
        {
            ShowOrHideInventory();
        }
       if (Input.GetButtonDown(testButton))
        {
            AddToInventory("HealPotion",3);
        }
    }
    
    // en cours de developpement
    void AddToInventory(string itemname, int count)
    {
       /* int ID = myitem.itemID;
        bool added = false;
        int i = 0;
        int l = inventory.Count;
        while (i<l||!added)
        {
            if (ID == inventory[i].itemID)
           {
                inventory[i].itemCount += item.itemCount;
               added = true;
           }
            else
            {*/
                if (inventorySlots.childCount == slotCount)
                {
                    Debug.Log("Inventory_player : AddInventory : Vous avez essayer d'ajouter un items dans l'inventaire alors que celui est plein");
                }
                else
                { 
                    // ajoute dans la liste d'item de l'inventaire
                    //inventory.Add(item);
                    // integratee new item in inventory
                    Transform newItem;
                    newItem = Instantiate(itemPrebHealPotion, Vector3.zero, Quaternion.identity) as Transform;
                    newItem.SetParent(inventorySlots, false);
                    // download item's data in inventory's slot
              /*      ItemSlots itemInventory = newItem.GetCompnent<ItemSlots>();
                    ItemVariable itemScene = item.GetCompnent<ItemVariable>();
                    itemInventory.itemName = itemScene.itemName;
                    itemInventory.itemID = itemScene.ID;
                    itemInventory.itemSprite = itemScene.itemSPrite;
                    itemInventory.itemDescription = itemScene.itemDescription; */
                }/*
            }
        }*/
    }
    

    // affiche / enleve l'inventaire sur l'écran, ajoute le curseur de la souris si besoin
    void ShowOrHideInventory ()
    {

        invetoryCanvas.SetActive(!inventoryOpen); // active l'inventaire ou le desactive

        //Gestion du curseur
        Cursor.visible = !inventoryOpen; // rend le curseur visible si l'inventaire et ouvert, invisible si l'interface est fermé
        if (inventoryOpen) // bloque le curseur hors de l'inventaire
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else // débloque le curseur dans l'inventaire
        {
            Cursor.lockState = CursorLockMode.None;
        }
        // inverse le booléen inventoryOpen
        inventoryOpen = !inventoryOpen;
    }
}
