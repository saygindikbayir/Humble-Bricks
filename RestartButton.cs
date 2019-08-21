using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    //public UnityEngine.UI.Button Button;

    //private void Start()
    //{
    //    Button.onClick.AddListener(RestartLevel);
    //}
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
