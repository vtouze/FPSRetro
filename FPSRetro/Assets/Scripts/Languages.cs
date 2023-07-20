using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization.Settings;
using UnityEngine;

public class Languages : MonoBehaviour
{
    private bool _active = false;

    public void ChangeLanguage(int languageID)
    {
        if(_active == true)
        {
            return;
        }
        StartCoroutine(SetLanguage(languageID));
        Debug.Log("fds");
    }

    IEnumerator SetLanguage(int _languageID)
    {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_languageID];
        _active = false;
    }
}
