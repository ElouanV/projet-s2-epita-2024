using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public GameObject Shop;
    public bool is_trigger;
    public bool is_shop = false;
    public GameObject ShopCanvas;
    public GameObject Bubble;
    public GameObject MainInterface;
    public GameObject Shop_MainInterface;

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
        if (is_trigger && Input.GetKeyUp(KeyCode.Space))
        {
            
            Bubble.SetActive(false);
            showshop();
        }
    }

    void showshop()
    {
        ShopCanvas.SetActive(!is_shop);
        MainInterface.SetActive(is_shop);
        

        Cursor.visible = !is_shop; 
        if (is_shop) 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        is_shop = !is_shop;
    }
}