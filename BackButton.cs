using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject MainMenuDisplay;
    public GameObject SettingsMenuDisplay;

    public void MainMenu()
    {
        MainMenuDisplay.SetActive(true);
        SettingsMenuDisplay.SetActive(false);
    }
}
