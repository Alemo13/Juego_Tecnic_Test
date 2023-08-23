using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneSO : MonoBehaviour
{
    public SceneSOSave sceneSO;
    private void Start()
    {
        // Cargar el ScriptableObject persistente desde los recursos
        SceneSOSave loadedScriptableObject = SceneSOSave.Instance;

        // Puedes asignar loadedScriptableObject a una variable local o utilizarlo directamente
        sceneSO = loadedScriptableObject;
    }
}
