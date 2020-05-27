using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Authors : Martin
public class ShowShop : MonoBehaviour
{
    public GameObject Shop;
    public bool is_trigger;
    public bool is_shop = false;
    public GameObject ShopCanvas;
    public GameObject Bubble;
    public GameObject MainInterface;
    public GameObject Shop_MainInterface;
    public Player player;
    public bool inventoryOpen = false;

    void OnTriggerEnter2D()
    {
        is_trigger = true;
    }

    void OnTriggerExit2D()
    {
        is_trigger = false;
        if (is_shop == true)
        {
            showshop();
        }
    }
    /// <summary>
    /// L'actualisaion.
    /// </summary>
    /// <remarks>
    /// <para>Active le panel du pnj</para>
    /// </remarks>
    void Update()
    {
        if (is_trigger && Input.GetKeyUp(KeyCode.Space))
        {
            
            Bubble.SetActive(false);
            showshop();
        }
    }

    /// <summary>
    /// L'aspect graphique.
    /// </summary>
    /// <remarks>
    /// <para>Regule les aspect graphique (main interface) </para>
    /// </remarks>
    void showshop()
    {
        ShopCanvas.SetActive(!is_shop&& !inventoryOpen);
        MainInterface.SetActive(is_shop);
        Cursor.visible = !is_shop&& !inventoryOpen; 
        if (is_shop) 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        is_shop = !is_shop;
        player.GetComponent<Inventory_test>().shopOpen = is_shop;
    }
}