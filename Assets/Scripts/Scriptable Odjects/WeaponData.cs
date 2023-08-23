using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponSO")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public string weaponType;
    public int phisicalDamage;
    public int magicDamage;
    public int defense;
    public GameObject sprite;
    public bool isEquiped;
}
