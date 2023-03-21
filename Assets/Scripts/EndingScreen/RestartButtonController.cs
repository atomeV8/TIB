using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonController : MonoBehaviour
{
    public void OnClickReplay()
    {
        StaticGameData.isLost = false;
        StaticGameData.Game.Points = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScreen");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("EndingScreen");

    }

}
