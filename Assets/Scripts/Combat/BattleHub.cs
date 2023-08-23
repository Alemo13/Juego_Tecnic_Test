using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleHub : MonoBehaviour
{
    public TextMeshProUGUI unitHealth;
    public TextMeshProUGUI unitDamage;
    public TextMeshProUGUI unitMagic;
    public TextMeshProUGUI unitDefense;

    public void SetHUD(UnitManager unit)
    {
        unitHealth.text = "Health: " + unit.currentHealth;
        unitDamage.text = "Damage: " + unit.damage;
        unitMagic.text = "Magic: " + unit.magic;
        unitDefense.text = "Defense: " + unit.def;
    }

    public void SetHP(float hp)
    {
        if(hp <= 0)
            unitHealth.text = "Health: 0";
        else
            unitHealth.text = "Health: " + hp;
    }
}
