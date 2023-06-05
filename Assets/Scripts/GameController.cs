using System.Collections;
using System.Collections.Generic;
using TIBLibrary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Game game;
    // Start is called before the first frame update
    public AudioClip impact;

    [SerializeField]
    private AudioClip winSoundEffect;
    [SerializeField]
    private AudioClip lossSoundEffect;
    void Start()
    {
        List<string> sceneList = new List<string>();

        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        string[] scenes = new string[sceneCount];


        for (int i = 0; i < sceneCount; i++)
        {
            if (System.IO.Path.GetFullPath(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)).Contains("Minigames"))
            {
                sceneList.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));
            }
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        game = new Game(sceneList);

        Randomizer.ShuffleMinigames<Minigame>(game.Minigames);

        StaticGameData.Game = game;
        StaticGameData.winSoundEffect = this.winSoundEffect;
        StaticGameData.lossSoundEffect = this.lossSoundEffect;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickStart()
    {
        GetComponent<AudioSource>().PlayOneShot(impact, 1F);
        SceneManager.LoadScene("LoadingScreen");

    }

    public void onClickQuit()
    {
        Application.Quit();
    }

    public void onClickOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
}

public static class StaticGameData
{
    public static Game Game { get; set; }
    public static int ActualMinigame { get; set; } = 0;
    public static bool isLost { get; set; } = false;
    public static AudioClip winSoundEffect { get; set; }
    public static AudioClip lossSoundEffect { get; set; }
    public static int playMusic { get; set; } = 1; //1 = yes
    public static int DirectorCount { get; set; } = 0;
    public static bool isMinigameHardMode { get; set; } = false;

    public static IEnumerator swapScene(float timeBetweenScene = 2f)
    {

        yield return new WaitForSeconds(timeBetweenScene);

        StaticGameData.Game.inMinigame = false;
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(StaticGameData.Game.Minigames[StaticGameData.ActualMinigame].SceneName);
        StaticGameData.ActualMinigame++;
        if (StaticGameData.ActualMinigame >= StaticGameData.Game.Minigames.Count)
        {
            StaticGameData.ActualMinigame = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("MinimapScreen");
            // Randomizer.ShuffleMinigames<Minigame>(StaticGameData.Game.Minigames);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScreen");
    }
}