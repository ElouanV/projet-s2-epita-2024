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
    public int count = 0;

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
    void Update()
    {
        if (is_trigger && Input.GetKeyUp(KeyCode.Space) && count == 0)
        {
            
            Bubble.SetActive(false);
            showshop();
            count += 1;
        }
        if (is_trigger && Input.GetKeyUp(KeyCode.Space) && count == 1)
        {
            showshop();
            Bubble.SetActive(true);
            count -= 1;
        }
    }

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