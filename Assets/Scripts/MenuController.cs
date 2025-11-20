using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Continue()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "MainMenu");
        SceneManager.LoadScene(lastScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
