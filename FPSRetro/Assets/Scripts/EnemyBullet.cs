using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private Rigidbody2D _rb = null;
    private Vector3 _direction;
    void Start()
    {
        _direction = PlayerController._playerInstance.transform.position;
        _direction.Normalize();
        _direction = _direction * _bulletSpeed;
    }

    void Update()
    {
        _rb.velocity = _direction * _bulletSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController._playerInstance.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }
    }
}
