using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Author : Settha
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

    public Player player;
    public GameObject PnjWithDialogue;



    public bool Test = false;
    
    public void ChangeTest()
    {
        Test = !Test;
    }

    /// <summary>
    /// Atualisé l'overlay en fonction des variable du player
    /// </summary>
    /// <remarks>
    /// <para>La première est l'argent</para>
    /// <para>La seconde et la vie </para>
    /// </remarks>

    // Update is called once per frame
    void Update()
    {
        TxtHp.text = "HP : " +  player.currenthp + " / " + player.hpmax; 
        TxtLvl.text = "Lvl : " +  player.Lvl ;  
        TxtArgent.text = "Argent : " +  player.argent + "€"; 
        TxtAtk.text = "Atk : " +  player.atk ;  
        TxtArmure.text = "Armure : " +  player.armure; 

        TxtLvl_Armure.text = "Lvl Armure : " +  player.armurelvl + "/3" ;
        TxtLvl_Epee.text = "Lvl Epee : " +  player.epeelvl + "/3"; 
        TxtLvl_Bouclier.text = "Lvl Bouclier : " +  player.bouclierlvl + "/3"; 
        TxtLvl_Casque.text ="Lvl Casque : " +  player.casquelvl + "/3"; 
    }
    

    //public string ListToString (int[][] ListeQuetes)
    // Cette fonction permettra que le personnage pick une quêtes à épingler dans l'affichage principale
    
}
