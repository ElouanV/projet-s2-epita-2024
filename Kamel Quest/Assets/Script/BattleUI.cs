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


    public void SetupHUD(Entity unit)
    {
        nameText.text = unit.name;
        lvlText.text = "Lvl " + unit.lvl.ToString();
        hpSlider.maxValue = unit.hpmax;
        hpSlider.value = unit.currenthp;

    }

    public void UpdateHp(long hp)
    {
        hpSlider.value = hp;
    }
}
