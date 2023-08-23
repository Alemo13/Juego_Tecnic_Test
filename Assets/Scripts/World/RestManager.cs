using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestManager : MonoBehaviour
{
    public RestSystem restSystem;
    public UnitData playerData;

    //public GameObject worldLimiter;

    public GameObject messageWindow;
    public TextMeshProUGUI windowMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float heal = restSystem.heal;
        float howHeal = playerData.currentHealth + heal;
        if (restSystem.isHealed != true)
        {
            messageWindow.SetActive(true);
            windowMessage.text = "You Recovery: " + restSystem.heal.ToString();
            if (howHeal >= playerData.health)
            {
                playerData.currentHealth = playerData.health;
            }
            else
            {
                playerData.currentHealth += heal;
            }
        }    
        restSystem.isHealed = true;
    }
    private void OnDestroy()
    {
        restSystem.isHealed = false;
    }
}
