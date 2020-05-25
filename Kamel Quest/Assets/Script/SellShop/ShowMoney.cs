using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour
{

    public Text TxtArgent;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        TxtArgent.text = "Argent : " +  player.argent + "€"; 
    }
}
