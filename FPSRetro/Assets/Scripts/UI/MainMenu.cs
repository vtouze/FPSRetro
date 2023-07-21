using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _checkQuit;
    [SerializeField] private GameObject _darker;
    private bool _isQuiting;

    void Start()
    {
        _isQuiting = false;
        if(_isQuiting == false)
        {
            _darker.SetActive(false);
            _checkQuit.SetActive(false);
        }

        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y) && _isQuiting == true)
        {
            QuitValid();
        }

        if (Input.GetKeyDown(KeyCode.N) && _isQuiting == true)
        {
            QuitNotValid();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Test");
    }

    public void OpenSettings()
    {
        _settingsMenu.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void QuitCheck()
    {
        _isQuiting = true;
        _checkQuit.SetActive(true);
        _darker.SetActive(true);
    }

    public void QuitNotValid()
    {
        _isQuiting = false;
        _checkQuit.SetActive(false);
        _darker.SetActive(false);
    }

    public void QuitValid()
    {
        Application.Quit();
    }

    public void Back()
    {
        _settingsMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
