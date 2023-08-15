using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UILanguages : MonoBehaviour
{
    [SerializeField] private Button _uk;
    [SerializeField] private Button _fr;
    [SerializeField] private Button _de;
    [SerializeField] private Button _se;
    [SerializeField] private Button _button;
    private int _inc;

    void Start()
    {
        _inc = 0;
    }
    public void OnClick()
    {
        _inc++;
    }

    void Update()
    {
        if(_inc >= 4)
        {
            _inc = 0;
        }
        if(_inc == 0)
        {
            _button.image.sprite = _uk.image.sprite;
        }
        if(_inc == 1)
        {
            _button.image.sprite = _fr.image.sprite;
        }
        if(_inc == 2)
        {
            _button.image.sprite = _de.image.sprite;
        }
        if(_inc == 3)
        {
            _button.image.sprite = _se.image.sprite;
        }
    }

}
