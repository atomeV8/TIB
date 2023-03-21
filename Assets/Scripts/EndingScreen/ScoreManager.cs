using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject HighScoreLabel;
    public GameObject ScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        HighScoreLabel = GameObject.Find("BestScore");
        ScoreLabel = GameObject.Find("PersonalScore");
        if (StaticGameData.Game.Points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", StaticGameData.Game.Points);
            HighScoreLabel.GetComponent<Text>().text = StaticGameData.Game.Points.ToString();
        }
        else
        {
            HighScoreLabel.GetComponent<Text>().text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        ScoreLabel.GetComponent<Text>().text = StaticGameData.Game.Points.ToString();

    }
}
