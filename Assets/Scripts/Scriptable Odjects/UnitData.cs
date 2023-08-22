using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/Unit Data")]
public class UnitData : ScriptableObject
{
    public new string name;
    public float health;
    public float currentHealth;
    public int damage;
    public int magic;
    public int defense;
    public bool isDenfended;

}
