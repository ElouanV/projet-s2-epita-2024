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
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lvlText;
    public UnityEngine.UI.Slider hpSlider;

    public TextMeshProUGUI unitHpText;
    


    public void SetupHUD(Entity unit)
    {
        nameText.text = unit.name;
        lvlText.text = "Lvl " + unit.lvl.ToString();
        hpSlider.maxValue = unit.hpmax;
        hpSlider.value = unit.currenthp;
        unitHpText.text = unit.currenthp + "/" + unit.hpmax;
        

    }

    public void UpdateHp(long hp, Entity unit)
    {
        hpSlider.value = hp;
        unitHpText.text = hp + "/" + unit.hpmax;
    }
}
