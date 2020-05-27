using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour
{

    public Text TxtArgent;
    public Player player;

    /// <summary>
    /// Fonction d'actualisation de l'argent du sell shop.
    /// </summary>
    /// <remarks>
    /// <para>L'argent vien du player</para>
    /// </remarks>

    // Update is called once per frame
    void Update()
    {
        TxtArgent.text = "Argent : " +  player.argent + "€"; 
    }
}
