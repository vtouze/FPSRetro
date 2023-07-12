using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_spriteRenderer.flipX = true;
    }

    void Update()
    {
        transform.LookAt(PlayerController._playerInstance.transform.position, -Vector3.forward);
    }
}
