using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScene : MonoBehaviour
{

    public void GameRestart()
    {
        SceneManager.LoadScene("MapScene");
        Time.timeScale = 1;
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}

