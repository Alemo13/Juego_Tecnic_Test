using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Scenes")]
public class BattleSystemSO : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
}
