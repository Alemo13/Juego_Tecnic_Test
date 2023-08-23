using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponData weaponData;

    public string weaponName;
    public int phisicalDamage;
    public int magicDamage;
    public int defense;
    public GameObject weaponSprite;
    public bool isEquiped;

    private void Awake()
    {
        weaponName = weaponData.name;
        phisicalDamage = weaponData.phisicalDamage;
        magicDamage = weaponData.magicDamage;
        defense = weaponData.defense;
        weaponSprite = weaponData.sprite;
        isEquiped = weaponData.isEquiped;
    }

}
