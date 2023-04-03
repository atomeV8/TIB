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
            StaticGameData.DirectorCount = 0;
            SceneManager.LoadScene("DirectorAngry");
            SceneManager.UnloadSceneAsync("LoadingScreen");
        }
        else
        {
            StaticGameData.DirectorCount++;
            SceneManager.LoadScene(StaticGameData.Game.Minigames[StaticGameData.ActualMinigame].SceneName);
            SceneManager.UnloadSceneAsync("LoadingScreen");
        }
    }
}
