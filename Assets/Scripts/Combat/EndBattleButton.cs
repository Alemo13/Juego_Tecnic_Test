using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBattleButton : MonoBehaviour
{
    public void OnContinueButton()
    {
        SceneSOSave.Instance.battleSystem.isDefeated = true;
        SceneManager.LoadScene("OverWorld");
    }
    public void OnRestartButton()
    {
        SceneSOSave.Instance.DeletePref();
        SceneManager.LoadScene("StartMenu");
    }
}
