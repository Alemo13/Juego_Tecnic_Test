using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public BattleSystemSO battleSystem;

    public GameObject worldLimiter;

    public GameObject messageWindow;
    public TextMeshProUGUI windowMessage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneSOSave.Instance.ChangeScriptObject(battleSystem);
        SceneSOSave.Instance.SavePosition();
        if (SceneSOSave.Instance.battleSystem.isDefeated != true)
        {               
            messageWindow.SetActive(true);
            windowMessage.text = "Battle vs:" + battleSystem.name.ToString();
        }
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
