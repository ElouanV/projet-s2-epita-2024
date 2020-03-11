using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{
    public Text TxtHp;
    public Text TxtLvl;
    public Text TxtArgent;

    public Text TxtQuetes;
    public Text ListeQuetes;

    public Entity entity;
    public Player player;

    public int p;
    

    // Update is called once per frame
    void Update()
    {
        TxtHp.text = "HP : " +  player.currenthp + " / " + player.hpmax; 
        TxtLvl.text = "Lvl : " +  player.Lvl ;  
        TxtArgent.text = "Argent : " +  player.argent + "€"; 
        TxtQuetes.text = "Listes des quêtes";
        // ListeQuetes.text = " -" + "quêtes épingnées";
    }

    //public string ListToString (int[][] ListeQuetes)
    // Cette fonction permettra que le personnage pick une quêtes à épingler dans l'affichage principale
    
}
