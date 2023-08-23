using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitManager : MonoBehaviour
{
    public UnitData unitData;

    public string nameUnit;
    public float health;
    public float currentHealth;
    public int damage;
    public int magic;
    public int def;
    public bool isDef;

    private void Awake()
    {
        nameUnit = unitData.name;
        health = unitData.health;
        currentHealth = unitData.currentHealth;
        damage = unitData.damage;
        magic = unitData.magic;
        def = unitData.defense;
        isDef = unitData.isDenfended;
    }
    public bool TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
            return true;
        else
            return false;
    }

}
