using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    public static PlayerController _playerInstance;
    [SerializeField] private Rigidbody2D _rb = null;
    [SerializeField] private float _moveSpeed;
    private Vector2 _moveInput;
    private Vector2 _mouseInput;
    [SerializeField] private float _mouseSensitivity = 1f;
    [SerializeField] private Camera _viewCamera = null;
    [SerializeField] private GameObject _bulletImpact = null;
    public int _currentAmmo;
    [SerializeField] private Animator _gunAnim;
    #endregion Fields

    void Awake()
    {
        _playerInstance = this;
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
        _viewCamera.transform.localRotation = Quaternion.Euler(_viewCamera.transform.localRotation.eulerAngles + new Vector3(0f, _mouseInput.y, 0f));
        #endregion Player View Control
        #region Shooting
        if(Input.GetMouseButtonDown(0))
        {
            if(_currentAmmo > 0)
            {
                Ray ray = _viewCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    //Debug.Log("I'm looking at " + hit.transform.name);
                    Instantiate(_bulletImpact, hit.point, transform.rotation);
                    if(hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                    }
                }
                else
                {
                    //Debug.Log("I'm looking at nothing!");
                }
                _currentAmmo--;
                _gunAnim.SetTrigger("Shoot");
            }
        }
        #endregion Shooting


        #endregion Methods
    }
}
