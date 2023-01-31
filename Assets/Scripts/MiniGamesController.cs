using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TIBLibrary;

public class MiniGamesController : MonoBehaviour
{
    
    void Start()
    {
        if (StaticGameData.isLost)
        {
            SceneManager.LoadScene("EndingScreen");
            SceneManager.UnloadSceneAsync("LoadingScreen");
        }
        else
        {
            SceneManager.LoadScene(StaticGameData.Game.Minigames[StaticGameData.ActualMinigame].SceneName);
            SceneManager.UnloadSceneAsync("LoadingScreen");
        }
    }
}
