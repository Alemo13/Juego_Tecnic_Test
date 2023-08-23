using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputAction mouseClickAction;
    [SerializeField] private float speedMove = 0.01f;
    [SerializeField] private Camera cam;
    private Vector3 targetPosition;
    private Coroutine coroutine; 

    private void Awake()
    {
        cam = Camera.main;
        if (PlayerPrefs.GetInt("Save") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
            SceneSOSave.Instance.LoadTransform();
    }
    private void OnEnable()
    {
        mouseClickAction.Enable();
        mouseClickAction.performed += Move;
    }
    private void OnDisable()
    {
        mouseClickAction.performed -= Move;
        mouseClickAction.Disable();
    }
    private void Move(InputAction.CallbackContext input)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        Vector2 target = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(PlayerMoveTowards(target));
        
        targetPosition = target;
    }
    private IEnumerator PlayerMoveTowards(Vector3 target)
    {
        //target.y = transform.position.y;
        //target.z = transform.position.z;
        while (transform.position != target)
        {
            Vector3 destination = Vector3.MoveTowards(transform.position, target, speedMove);
            // Debug.Log("destination: " + destination);
            transform.position = destination;
            yield return null;
        }
    }
}
