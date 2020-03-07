using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCSupport : MonoBehaviour
{
    public GameObject playercam;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpscomp;

    [Header ("Button list")]
    public string inventoryButton;
    public GameObject invetoryCanvas;
    [Header("Inventory's Data")]
    [HideInInspector] public bool inventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playercam == null)
        {
            playercam = GameObject.FindWithTag("MainCamera");
        }

        fpscomp = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
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

        invetoryCanvas.SetActive(!inventoryOpen); // active l'inventaire

        fpscomp.enabled = inventoryOpen; // ouvre l'inventaire
        
        //Gestion ddu curseur
        Cursor.visible = !inventoryOpen; // rend le curseur visible
        if (inventoryOpen) // bloque le curseur hors de l'inventaire
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else // débloque le curseur dans l'inventaire
        {
            Cursor.lockState = CursorLockMode.None;
        }
        inventoryOpen = !inventoryOpen;
    }
}
