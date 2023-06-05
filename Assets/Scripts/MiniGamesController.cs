using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamesController : MonoBehaviour
{

    void Start()
    {
        if (StaticGameData.isLost)
        {
            StaticGameData.DirectorCount = 0;
            SceneManager.LoadScene("EndingScreen");
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
