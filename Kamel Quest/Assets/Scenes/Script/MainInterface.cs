using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInterface : MonoBehaviour
{
    public Text TxtHp;
    public Text TxtLvl;
    public Text TxtAtk;
    public Text TxtPtsQuete;
    public Text TxtArgent;

    public Entity entity;
    public Player player;
    

    // Update is called once per frame
    void Update()
    {
        TxtHp.text = "HP : " +  player.currenthp + " / " + player.hpmax; 
        TxtLvl.text = "Lvl : " +  player.Lvl ;  
        TxtAtk.text = "Attaque : " +  player.atk + " / "; 
        TxtPtsQuete.text = "P.Q. : " +  player.PtsQuete + " / "; 
        TxtArgent.text = "Argent : " +  player.argent + " / "; 
    }
}
