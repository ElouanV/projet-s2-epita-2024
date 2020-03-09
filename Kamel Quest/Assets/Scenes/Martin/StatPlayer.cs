using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Donne acces au varialbe de type text

public class StatPlayer : MonoBehaviour
{
    //Variables
    public int faim = 50;
    public int soif = 30;
    public int argent = 13;

    public Text TxtFaim;
    public Text TxtSoif;
    public Text TxtArgent;

    void Start()
    {
        UpdateStats();
    }

    // Public pour l'accessibilité au script (=Mise à jours stat)
    public void UpdateStats ()
    {
        TxtFaim.text = "Faim : " + faim + "%";
        TxtSoif.text = "Soif : " + soif + "%";
        TxtArgent.text = "Argent : " + argent + "€";
    }
}
