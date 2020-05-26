using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UIElements.Slider;

public class BattleUI : MonoBehaviour
{

     
    
    //joueur
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lvlText;
    public UnityEngine.UI.Slider hpSlider;
    public TextMeshProUGUI unitHpText;
    
    //alliés
    public TextMeshProUGUI ally1NameText;
    public TextMeshProUGUI ally1LvlText;
    public UnityEngine.UI.Slider ally1HpSlider;
    public TextMeshProUGUI ally1HpText;
    
    public TextMeshProUGUI ally2NameText;
    public TextMeshProUGUI ally2LvlText;
    public UnityEngine.UI.Slider ally2HpSlider;
    public TextMeshProUGUI ally2HpText;
    
    
    
    

    
    


    public void SetupHUD(Entity unit, Entity ally1, Entity ally2)
    {
        if (unit.isalive)
        {
            nameText.text = unit.name;
            lvlText.text = "Lvl " + unit.lvl;
            hpSlider.maxValue = unit.hpmax;
            hpSlider.value = unit.currenthp;
            unitHpText.text = unit.currenthp + "/" + unit.hpmax;
        }
        else
        {
            nameText.text = "";
            lvlText.text = "";
            hpSlider.gameObject.SetActive(false);
            hpSlider.value = 0;
            unitHpText.text = "";
        }


        //alliés

        if (ally1.isalive)
        {
            ally1NameText.text = ally1.name;
            ally1LvlText.text = "Lvl " + ally1.lvl;
            ally1HpSlider.maxValue = ally1.hpmax;
            ally1HpSlider.value = ally1.currenthp;
            ally1HpText.text = ally1.currenthp + "/" + ally1.hpmax;
        }
        else
        {
            ally1NameText.text = "";
            ally1LvlText.text = "";
            ally1HpSlider.gameObject.SetActive(false) ;
            ally1HpSlider.value = 0;
            ally1HpText.text = "";
        }

        if (ally2.isalive)
        {
            ally2NameText.text = ally2.name;
            ally2LvlText.text = "Lvl " + ally2.lvl;
            ally2HpSlider.maxValue = ally2.hpmax;
            ally2HpSlider.value = ally2.currenthp;
            ally2HpText.text = ally2.currenthp + "/" + ally2.hpmax;
        }
        else
        {
            ally2NameText.text = "";
            ally2LvlText.text = "";
            ally2HpSlider.gameObject.SetActive(false) ;
            ally2HpSlider.value = 0;
            ally2HpText.text = "";
        }
    }
    
    public void UpdateHp(long hp, Entity unit, UnityEngine.UI.Slider slider, TextMeshProUGUI hpText)
    {
        
        slider.value = hp;
        hpText.text = hp + "/" + unit.hpmax;

    }
    
}
