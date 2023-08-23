using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public WeaponData weaponData;
    public UnitData playerData;
    public GameObject playerPrefab;

    public int dmg;
    public int magic;
    public int def;

    public static ShopManager Instance { get; private set; }
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
    private void Start()
    {
        dmg = playerData.damage;
        magic = playerData.magic;
        def = playerData.defense;
    }

    public void WeaponEquiped()
    {
        if (!weaponData.isEquiped)
        {
            playerData.damage += weaponData.phisicalDamage;
            playerData.magic += weaponData.magicDamage;
            playerData.defense += weaponData.defense;
            weaponData.isEquiped = true;
        }
    }
    private void OnDestroy()
    {
        WeaponUnequip();
    }
    public void WeaponUnequip()
    {
        if (weaponData.isEquiped)
        {
            playerData.damage = dmg;
            playerData.magic = magic;
            playerData.defense = def;
            weaponData.isEquiped = false;
        }
    }
}
