using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoShop : MonoBehaviour
{
    public GameObject MainInterface;
    public GameObject Shop;
    public bool is_trigger;
    public bool is_shop;
    public Player player;

    public Text TxtInfoArmure;
    public Text TxtInfEpee;
    public Text TxtInfoBouclier;
    public Text TxtInfoCasque;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TxtInfoArmure.text = "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_ARMURELVL[player.armurelvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_ARMURE[player.armurelvl] + " Armure.";
        TxtInfEpee.text =  "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_EPEELVL[player.epeelvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_ATTACK[player.epeelvl] + " Attack.";
        TxtInfoBouclier.text =  "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_BOUCLIERLVL[player.bouclierlvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_HPMAX[player.bouclierlvl] + " HP MAX.";
        TxtInfoCasque.text =  "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_CASQUELVL[player.casquelvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_ARMURE[player.casquelvl] + " Armure.";
    }
}
