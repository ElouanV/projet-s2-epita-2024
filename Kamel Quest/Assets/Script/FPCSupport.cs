using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCSupport : MonoBehaviour
{
    public GameObject playercam;
    //private GameObject objetInteract;
    [Header ("Button list")]
    public string inventoryButton;
    //public string interactButtonn;

    //[Header ("Tag's list")]
    //public string itemTag = "Item";
    
    [Header("Inventory's Data")]
    public GameObject invetoryCanvas;
    [HideInInspector] public bool inventoryOpen = false;


    //[Header("Other")]
    //public Transform itemPrefab;
   // public Transform inventorySlots;
   // public int slotCount = 20; // taille de l'inventaire limité à 20


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
    }
    


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
