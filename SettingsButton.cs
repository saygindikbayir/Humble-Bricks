using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public GameObject MainMenuDisplay;
    public GameObject SettingsMenuDisplay;

    public void SettingsMenu()
    {
        MainMenuDisplay.SetActive(false);
        SettingsMenuDisplay.SetActive(true);
    }
    
}
