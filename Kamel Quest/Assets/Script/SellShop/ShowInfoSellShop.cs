using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Author : Martin 
public class ShowInfoSellShop : MonoBehaviour
{
    public Player player1;

    public Text TxtInfoItem1t;
    public Text TxtInfoItem2t;
    public Text TxtInfoItem3t;
    public Text TxtInfoItem4t;
    public Text TxtInfoItem5t;
    public Text TxtInfoItem6t;
    public Text TxtInfoItem7t;
    public Text TxtInfoItem8t;
    public Text TxtInfoItem9t;
    public Text TxtInfoItem10t;
    public Text TxtInfoItem11t;
    public Text TxtInfoItem12t;

    public GameObject TxtInfoItem1;
    public GameObject TxtInfoItem2;
    public GameObject TxtInfoItem3;
    public GameObject TxtInfoItem4;
    public GameObject TxtInfoItem5;
    public GameObject TxtInfoItem6;
    public GameObject TxtInfoItem7;
    public GameObject TxtInfoItem8;
    public GameObject TxtInfoItem9;
    public GameObject TxtInfoItem10;
    public GameObject TxtInfoItem11;
    public GameObject TxtInfoItem12;

    public int[] LVL_TO_ARGENT = {10, 25, 40, 60, 100};

    /// <summary>
    /// Fonction d'actualisation de des informations de chaque boutons du sell shop.
    /// </summary>
    /// <remarks>
    /// <para>Cela se déclanche au survole</para>
    /// </remarks>    

    /// transform.parent.GetComponent<BoutonSellShop>().LVL_TO_ARGENT[Item1.lvl]
    // Update is called once per frame
    void Update()
    {
        TxtInfoItem1t.text = "Vend ta potion de soin est gagne : 10KC";
        TxtInfoItem2t.text =  "Vend ta relic de monstre est gagne : 10KC";
        TxtInfoItem3t.text =  "Vend ta Buission est gagne : 10KC";
        TxtInfoItem4t.text =  "Vend ta Strenght est gagne : 10KC";
        TxtInfoItem5t.text =  "Vend ta bougie est gagne : 25KC";
        TxtInfoItem6t.text =  "Vend ta potion de dégat est gagne : 10KC";
        TxtInfoItem7t.text =  "Vend ton armure usée est gagne : 25KC";
        TxtInfoItem8t.text =  "Vend ta poisson est gagne : 10KC";
        TxtInfoItem9t.text =  "Vend ta bûche rouge est gagne : 10KC";
        TxtInfoItem10t.text =  "Vend ton fleur est gagne : 25KC";
        TxtInfoItem11t.text =  "Vend tes gant usée est gagne : 40KC";
        TxtInfoItem12t.text =  "Vend ta bottes usées est gagne : 25KC";
    }

    public void ActiveTextItem1 () /// == potion
    {
        TxtInfoItem1.SetActive(true);
    }

    public void DisableTextItem1 () /// == potion
    {
        TxtInfoItem1.SetActive(false);   
    }

    public void ActiveTextItem2 () 
    {
        TxtInfoItem2.SetActive(true);
    }

    public void DisableTextItem2 ()
    {
        TxtInfoItem2.SetActive(false);   
    }

    public void ActiveTextItem3 () 
    {
        TxtInfoItem3.SetActive(true);
    }

    public void DisableTextItem3 ()
    {
        TxtInfoItem3.SetActive(false);   
    }

    public void ActiveTextItem4 () 
    {
        TxtInfoItem4.SetActive(true);
    }

    public void DisableTextItem4 ()
    {
        TxtInfoItem4.SetActive(false);   
    }

    public void ActiveTextItem5 () 
    {
        TxtInfoItem5.SetActive(true);
    }

    public void DisableTextItem5 ()
    {
        TxtInfoItem5.SetActive(false);   
    }

    public void ActiveTextItem6 () 
    {
        TxtInfoItem6.SetActive(true);
    }

    public void DisableTextItem6 ()
    {
        TxtInfoItem6.SetActive(false);   
    }

    public void ActiveTextItem7 () 
    {
        TxtInfoItem7.SetActive(true);
    }

    public void DisableTextItem7 ()
    {
        TxtInfoItem7.SetActive(false);   
    }

    public void ActiveTextItem8 () 
    {
        TxtInfoItem8.SetActive(true);
    }

    public void DisableTextItem8 ()
    {
        TxtInfoItem8.SetActive(false);   
    }

    public void ActiveTextItem9 () 
    {
        TxtInfoItem9.SetActive(true);
    }

    public void DisableTextItem9 ()
    {
        TxtInfoItem9.SetActive(false);   
    }

    public void ActiveTextItem10 () 
    {
        TxtInfoItem10.SetActive(true);
    }

    public void DisableTextItem10 ()
    {
        TxtInfoItem10.SetActive(false);   
    }

    public void ActiveTextItem11 () 
    {
        TxtInfoItem11.SetActive(true);
    }

    public void DisableTextItem11 ()
    {
        TxtInfoItem11.SetActive(false);   
    }

    public void ActiveTextItem12 () 
    {
        TxtInfoItem12.SetActive(true);
    }

    public void DisableTextItem12 ()
    {
        TxtInfoItem12.SetActive(false);   
    }

    /// faire pour les 12 items

    public void Shop_Item1()
    {
      /// + supp l'objet
      player1.argent += LVL_TO_ARGENT[TxtInfoItem1.GetComponent<Items>().lvl];
      
    }
}
