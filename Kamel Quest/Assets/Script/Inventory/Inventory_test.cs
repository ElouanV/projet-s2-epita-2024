using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_test : MonoBehaviour
{
    [Header ("En cours de développement")]
     //rien
   
    
    public GameObject playercam;
    
    [Header ("Button list")]
    public string inventoryButton;
    [Header("Pour mes test")]
    public string testButton;
    public string test2Button = "Test2";
    public string test3Button = "Test3";
    public Sprite healPotionSprite;
    public Sprite monsterRelicSprite;
    
    [Header("Inventory's Data")]
    public GameObject invetoryCanvas;
    [HideInInspector] public bool inventoryOpen = false;

    public Transform inventorySlots;
    public int slotCount = 20; // Inventory's size,, limit to 20
     

    [Header("ItemSlot")]
    public GameObject[] arrItemsSlot = new GameObject[20];
    

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
    
    // Ajoute un élèment pas encore présent dans l'inventaire
    // Debug.Log pour tester la fonction
    // Amélioration : Créer une limite de stack pour éviter de faire exploser le PC du jury à la soutenance finale
    // A faire : Si l'inventaire est plein, doit retourner faux afin que dans la boutique, un achat ne puisse pas être fait si l'inventaire est plein
    void AddToInventory(int ID, string name, int counttoadd, string description, Sprite sprite)
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
            if (item.itemID == ID)
            {
                item.itemCount += counttoadd;
                done = true;
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

