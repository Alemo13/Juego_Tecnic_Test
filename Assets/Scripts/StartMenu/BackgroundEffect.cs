using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffect : MonoBehaviour
{
    public Vector2 speed;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        offset = speed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
