using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public GameObject messageWindow;
    public TextMeshProUGUI windowMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        messageWindow.SetActive(true);
        windowMessage.text = "Congratulations You Finish!!";
    }
    public void OnButtonPress()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
