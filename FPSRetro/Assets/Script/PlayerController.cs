using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody2D _rb = null;
    [SerializeField] private float _moveSpeed;
    private Vector2 _moveInput;
    private Vector2 _mouseInput;
    [SerializeField] private float _mouseSensitivity = 1f;
    [SerializeField] private Transform _viewCamera = null;
    #endregion Fields

    void Start()
    {
        
    }

    void Update()
    {
        #region Methods

        #region Player Movement
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.up * -_moveInput.x;
        Vector3 moveVertical = transform.right * _moveInput.y;
        _rb.velocity = (moveHorizontal + moveVertical) * _moveSpeed;
        #endregion Player Movement
        #region Player View Control
        _mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * _mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - _mouseInput.x);
        _viewCamera.localRotation = Quaternion.Euler(_viewCamera.localRotation.eulerAngles + new Vector3(0f, _mouseInput.y, 0f));
        #endregion Player View Control
        #endregion Methods
    }
}
