using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int lastPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticGameData.Game.Points > lastPoints) {
            lastPoints = StaticGameData.Game.Points;
        }
        this.GetComponent<Text>().text = "" + lastPoints;
    }
}
