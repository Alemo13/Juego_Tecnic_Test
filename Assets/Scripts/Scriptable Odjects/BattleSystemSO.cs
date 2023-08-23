using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/BattlePref")]
public class BattleSystemSO : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public bool isDefeated;
}
