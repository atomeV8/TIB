using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInteract : MonoBehaviour
{

    private int interactions = 0;

    private AudioSource cnc;

    [SerializeField]
    private GameObject failedOverlay;

    [SerializeField]
    private float timeRemaining = 0.0f;

    bool hasWon = false;

    //public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        failedOverlay.SetActive(false);
        cnc = GetComponent<AudioSource>();
        cnc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactions > 0)
        {
            failedOverlay.SetActive(true);
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //timeText.text = timeRemaining.ToString();
        }
        else if(!hasWon)
        {
            GetComponents<AudioSource>()[0].Stop();
            GetComponents<AudioSource>()[1].Stop();
            GetComponents<AudioSource>()[1].PlayOneShot(StaticGameData.winSoundEffect, 0.5f);
            hasWon = true;
            print("Gagne");                                                                                     //Jeu gagné
            StaticGameData.Game.Points++;
            StartCoroutine(StaticGameData.swapScene());
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            GetComponents<AudioSource>()[0].Stop();
            GetComponents<AudioSource>()[1].Stop();
            GetComponents<AudioSource>()[1].PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
            interactions++;
            print("Perdu");                                                                                     //Jeu perdu
            print("Interactions : " + interactions + ", KeyCode : " + e.keyCode);
            StaticGameData.isLost = true;
            StartCoroutine(StaticGameData.swapScene());
        }
        if(e.isMouse)
        {

            GetComponents<AudioSource>()[0].Stop();
            GetComponents<AudioSource>()[1].Stop();
            GetComponents<AudioSource>()[1].PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
            interactions++;
            print("Perdu");                                                                                     //Jeu perdu
            print("Interaction : " + interactions + ", Mouse clicked !");
            StaticGameData.isLost = true;
            StartCoroutine(StaticGameData.swapScene());
        }
    }
}
