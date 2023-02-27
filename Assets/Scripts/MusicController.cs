using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name + " " + PlayerPrefs.GetInt("playMusic"));
        
        if (PlayerPrefs.GetInt("playMusic") == 0)
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else if (PlayerPrefs.GetInt("playMusic") == 1)
        {
            GetComponent<AudioSource>().enabled = true;
        }
    }
}
