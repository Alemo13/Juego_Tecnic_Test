using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SODefaultManager : MonoBehaviour
{
    public UnitData playerData;
    public BattleSystemSO battl1;
    public BattleSystemSO battl2;
    public BattleSystemSO battl3;

    private UnitData playerDefault;
    private BattleSystemSO battlDefault1;
    private BattleSystemSO battlDefault2;
    private BattleSystemSO battlDefault3;

    public static SODefaultManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    private void OnEnable()
    {
        playerDefault = playerData;
        battlDefault1 = battl1;
        battlDefault2 = battl2;
        battlDefault3 = battl3;
    }

    private void OnDisable()
    {
        playerData = playerDefault;
        battl1 = battlDefault1;
        battl2 = battlDefault2;
        battl3 = battlDefault3;
    }
}
