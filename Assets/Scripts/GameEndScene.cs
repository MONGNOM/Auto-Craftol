using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScene : MonoBehaviour
{

    public void GameRestart()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}

