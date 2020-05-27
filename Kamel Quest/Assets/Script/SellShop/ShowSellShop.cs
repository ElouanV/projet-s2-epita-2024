using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSellShop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SellShop;
    public bool is_trigger;
    public bool is_sellshop = false;
    public GameObject ShopCanvas;
    public GameObject Bubble;
    public GameObject MainInterface;
    public GameObject Interface_Sell_Shop;
    public Player player;
    public bool inventoryOpen = false;

    void OnTriggerEnter2D()
    {
        is_trigger = true;
    }

    void OnTriggerExit2D()
    {
        is_trigger = false;
        if (is_sellshop == true)
        {
            show_sell_shop();
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
            show_sell_shop();
        }
    }

    /// <summary>
    /// L'aspect graphique.
    /// </summary>
    /// <remarks>
    /// <para>Regule les aspect graphique (main interface) </para>
    /// </remarks>

    void show_sell_shop()
    {
        Interface_Sell_Shop.SetActive(!is_sellshop && !inventoryOpen);
        MainInterface.SetActive(is_sellshop);
        Cursor.visible = !is_sellshop && !inventoryOpen; 
        if (is_sellshop) 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        is_sellshop = !is_sellshop;
        player.GetComponent<Inventory_test>().sellshopOpen = is_sellshop;
    }
}