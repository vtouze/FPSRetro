using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public bool _hasKnifeInHand;
    [SerializeField] private GameObject _knife;
    public PlayerController _playerController;
    public Animator _knifeSelection;
    [SerializeField] private GameObject _weaponsSelection;
    [SerializeField] private Text _ammoText;
    private string _ammoNone = "/";

    void Start()
    {
        _knife.SetActive(false);
        _hasKnifeInHand = false;
        _weaponsSelection.SetActive(false);
        _ammoText.text = "";
        _ammoText.text = _ammoNone;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //_weaponsSelection.SetActive(true);
            _knifeSelection.SetTrigger("GetKnife");
            _playerController._hasShotgunInHand = false;
            _playerController.HasShotgun();
            _hasKnifeInHand = true;
            HasKnife();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {           
            //_weaponsSelection.SetActive(true);
            _playerController._shotgunSelection.SetTrigger("GetShotgun");
            _playerController._hasShotgunInHand = true;
            _playerController.HasShotgun();
            _hasKnifeInHand = false;
            HasKnife();
        }
    }

    public void HasKnife()
    {
        if(_hasKnifeInHand)
        {
            _knife.SetActive(true);
        }
        else
        {
            _knife.SetActive(false);
        }
    }
}
