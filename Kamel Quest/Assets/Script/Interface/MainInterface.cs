using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{

    public Text TxtHp;
    public Text TxtLvl;
    public Text TxtArgent;
    public Text TxtAtk;
    public Text TxtArmure;
    //Equipement
    public Text TxtLvl_Armure;
    public Text TxtLvl_Epee;
    public Text TxtLvl_Bouclier;
    public Text TxtLvl_Casque;

    public Text TxtInfoArmure;
    public Text TxtInfEpee;
    public Text TxtInfoBouclier;
    public Text TxtInfoCasque;

    public Player player;
    public bool shop;
    

    // Update is called once per frame
    void Update()
    {
        TxtHp.text = "HP : " +  player.currenthp + " / " + player.hpmax; 
        TxtLvl.text = "Lvl : " +  player.Lvl ;  
        TxtArgent.text = "Argent : " +  player.argent + "€"; 
        TxtAtk.text = "Atk : " +  player.atk ;  
        TxtArmure.text = "Armure : " +  player.armure; 

        TxtLvl_Armure.text = "Lvl Armure : " +  player.armurelvl + "/3";
        TxtLvl_Epee.text = "Lvl Epee : " +  player.epeelvl + "/3"; 
        TxtLvl_Bouclier.text = "Lvl Bouclier : " +  player.bouclierlvl + "/3"; 
        TxtLvl_Casque.text ="Lvl Casque : " +  player.casquelvl + "/3"; 

        


        TxtInfoArmure.text = "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_ARMURELVL[player.armurelvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_ARMURE[player.armurelvl] + " Armure.";
        TxtInfEpee.text =  "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_EPEELVL[player.epeelvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_ATTACK[player.epeelvl] + " Attack.";
        TxtInfoBouclier.text =  "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_BOUCLIERLVL[player.bouclierlvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_HPMAX[player.bouclierlvl] + " HP MAX.";
        TxtInfoCasque.text =  "Cout : " + transform.parent.GetComponent<Bouton>().UGRADE_CASQUELVL[player.casquelvl] + " € | " + "Gain : " + transform.parent.GetComponent<Bouton>(). ADD_ARMURE[player.casquelvl] + " Armure.";
    }

    

    //public string ListToString (int[][] ListeQuetes)
    // Cette fonction permettra que le personnage pick une quêtes à épingler dans l'affichage principale
    
}
