using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public WeaponData weaponData;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI weaponDamage;
    public TextMeshProUGUI message;

    public GameObject messageWindow;


    private void Start()
    {
        weaponName.text = weaponData.weaponName;
        if(weaponData.phisicalDamage == 0)
        {
            weaponDamage.text = "Magical Damage: " + weaponData.magicDamage.ToString();
        }
        else
        {
            weaponDamage.text = "Damage: " + weaponData.phisicalDamage.ToString();
        }
        
    }

    public IEnumerator Panel(WeaponData wD)
    {
        messageWindow.SetActive(true);
        message.text = "You Purchase a: " + wD.weaponName;
        yield return new WaitForSeconds(3f);

    }

    public void OnButtonPress()
    {
        ShopManager.Instance.weaponData = weaponData;
        ShopManager.Instance.WeaponEquiped();
        StartCoroutine(Panel(weaponData));
    }
}
