using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lvlText;

    public void SetupHUD(Entity unit)
    {
        nameText.text = unit.name;
        lvlText.text = unit.lvl.ToString();
    }
}
