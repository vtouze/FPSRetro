using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject _pin1;
    [SerializeField] private GameObject _pin2;
    [SerializeField] private GameObject _pin3;
    [SerializeField] private GameObject _pin4;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Continue()
    {
        _pin1.SetActive(true);
    }

    public void NewGame()
    {
        _pin2.SetActive(true);
    }

    public void Settings()
    {
        _pin3.SetActive(true);
    }

    public void Quit()
    {
        _pin4.SetActive(true);
    }
    
    public void ExitContinue()
    {
        _pin1.SetActive(false);
    }

    public void ExitNewGame()
    {
        _pin2.SetActive(false);
    }

    public void ExitSettings()
    {
        _pin3.SetActive(false);
    }

    public void ExitQuit()
    {
        _pin4.SetActive(false);
    }
}
