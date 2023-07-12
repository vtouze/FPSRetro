using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, _lifeTime);
    }
}
