using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("MinimapScene");
            SceneManager.UnloadSceneAsync("LoadingScreen");
        }
    }
}
