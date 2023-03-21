using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnters : MonoBehaviour
{
    public bool ballEntered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PaperBall")
        {
            AudioSource ads = GameObject.Find("GameController").GetComponent<AudioSource>();
            ads.Stop();
            ads.PlayOneShot(StaticGameData.winSoundEffect, 0.5f);
            print("victoire");
            //La balle est rentrée = victoire 
            //IL GAGNE ICI
            StaticGameData.Game.Points++;
            StartCoroutine(StaticGameData.swapScene());
            ballEntered = true;
        }
    }
}
