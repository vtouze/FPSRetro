using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _doorModel;
    [SerializeField] private GameObject _collider;
    [SerializeField] private float _openSpeed;
    private bool _shouldOpen;
    void Start()
    {
        
    }

    void Update()
    {
        if(_shouldOpen && _doorModel.position.z != 1f)
        {
            _doorModel.position = Vector3.MoveTowards(_doorModel.position, new Vector3(_doorModel.position.x, _doorModel.position.y, 1f), _openSpeed * Time.deltaTime);
            if(_doorModel.position.z == 1f)
            {
                _collider.SetActive(false);
            }
            else if(!_shouldOpen && _doorModel.position.z != 0f)
            {
                _doorModel.position = Vector3.MoveTowards(_doorModel.position, new Vector3(_doorModel.position.x, _doorModel.position.y, 0f), _openSpeed * Time.deltaTime);
                if (_doorModel.position.z == 0f)
                {
                    _collider.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shouldOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _shouldOpen = false;
        }
    }
}
