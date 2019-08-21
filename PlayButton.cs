using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayButtonClick()
    {
        //SceneManager.LoadScene("Level 1", LoadSceneMode.Additive);
        //SceneManager.UnloadSceneAsync("MainMenu");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level 1");
    }

}
