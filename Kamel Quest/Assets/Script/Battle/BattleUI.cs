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
        nameText.text = unit.name;
        lvlText.text = "Lvl " + unit.lvl;
        hpSlider.maxValue = unit.hpmax;
        hpSlider.value = unit.currenthp;
        unitHpText.text = unit.currenthp + "/" + unit.hpmax;
        
        
        //alliés
        
        ally1NameText.text = ally1.name;
        ally1LvlText.text = "Lvl " + ally1.lvl;
        ally1HpSlider.maxValue = ally1.hpmax;
        ally1HpSlider.value = ally1.currenthp;
        ally1HpText.text = ally1.currenthp + "/" + ally1.hpmax;
        
        ally2NameText.text = ally2.name;
        ally2LvlText.text = "Lvl " + ally2.lvl;
        ally2HpSlider.maxValue = ally2.hpmax;
        ally2HpSlider.value = ally2.currenthp;
        ally2HpText.text = ally2.currenthp + "/" + ally2.hpmax;
        


    }

    public void UpdateHp(long hp, Entity unit)
    {
        hpSlider.value = hp;
        unitHpText.text = hp + "/" + unit.hpmax;
    }
}
