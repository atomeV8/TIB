using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("playMusic") == 1)
        {
            GameObject.Find("Speaker_on").GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else if (PlayerPrefs.GetInt("playMusic") == 0)
        {
            GameObject.Find("Speaker_on").GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMusicButtonClick()
    {
        if(PlayerPrefs.GetInt("playMusic") == 0)
        {
            Debug.Log("Music ON");
            PlayerPrefs.SetInt("playMusic", 1);
            GameObject.Find("Speaker_on").GetComponent<SpriteRenderer>().sortingOrder = 1;
            GetComponent<AudioSource>().enabled = true;
        }
        else if(PlayerPrefs.GetInt("playMusic")  == 1)
        {
            Debug.Log("Music OFF");
            PlayerPrefs.SetInt("playMusic", 0);
            GameObject.Find("Speaker_on").GetComponent<SpriteRenderer>().sortingOrder = -1;
            GetComponent<AudioSource>().enabled = false;
        }
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadSceneAsync("OptionsScene");
    }
}
