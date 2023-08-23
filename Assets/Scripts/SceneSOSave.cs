using UnityEngine;

public class SceneSOSave : MonoBehaviour
{
    public BattleSystemSO battleSystem;
    public GameObject player;

    public static SceneSOSave Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
    private void Start()
    {
        if(PlayerPrefs.GetInt("Save") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("x");
            pY = PlayerPrefs.GetFloat("y");
            player.transform.position = new Vector2(pX, pY);
            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
    }
    public void ChangeScriptObject(BattleSystemSO so)
    {
        battleSystem = so;               
    }
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
        PlayerPrefs.SetInt("Save", 1);
        PlayerPrefs.Save();
    }
    public void LoadTransform()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
    public void DeletePref()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        PlayerPrefs.DeleteKey("z");
        PlayerPrefs.DeleteKey("Save");
        PlayerPrefs.DeleteKey("TimeToLoad");
    }
    private void OnDestroy()
    {
        DeletePref();   
    }
    private void OnDisable()
    {
        battleSystem.isDefeated = false;
    }
}
