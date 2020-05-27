using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Author : Martin
public class BoutonSellShop : MonoBehaviour
{

    public Player player;
    public bool running = false;

    public GameObject player1;

    public GameObject Item1; /// == potion
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;
    public GameObject Item7;
    public GameObject Item8;
    public GameObject Item9;
    public GameObject Item10;
    public GameObject Item11;
    public GameObject Item12;

    /// <summary>
    /// Bouton du SellShop
    /// </summary>
    /// <remarks>
    /// <para>Est apppelllé lors d'un clique </para>
    /// <para>en fonction du lvl de l'item </para>
    /// <para>12 idems en fonctions de l'id </para>
    /// </remarks>

    ///VENTE
    public int[] LVL_TO_ARGENT = {10, 25, 40, 60, 100};

    public void Sell_Item (GameObject Item)
    {
        if (player.GetComponent<Inventory_test>().isInInventory(Item.GetComponent<Items>().itemID, 1))
        {
            player.argent += LVL_TO_ARGENT[Item.GetComponent<Items>().lvl];
            player.GetComponent<Inventory_test>().RemoveFromInventory(Item.GetComponent<Items>().itemID, 1);
        }
        
    }

    public void Sell_Item1 ()
    {
        Sell_Item(Item1);
    }

    public void Sell_Item2 ()
    {
        Sell_Item(Item2);
    }

    public void Sell_Item3 ()
    {
        Sell_Item(Item3);
    }

    public void Sell_Item4 ()
    {
        Sell_Item(Item4);
    }

    public void Sell_Item5 ()
    {
        Sell_Item(Item5);
    }

    public void Sell_Item6 ()
    {
        Sell_Item(Item6);
    }

    public void Sell_Item7 ()
    {
        Sell_Item(Item7);
    }

    public void Sell_Item8 ()
    {
        Sell_Item(Item8);
    }

    public void Sell_Item9 ()
    {
        Sell_Item(Item9);
    }

    public void Sell_Item10 ()
    {
        Sell_Item(Item10);
    }

    public void Sell_Item11 ()
    {
        Sell_Item(Item11);
    }

    public void Sell_Item12 ()
    {
        Sell_Item(Item12);
    }
    


    ///INFORMATION DE L'ECHANGE (on click)

    
}
