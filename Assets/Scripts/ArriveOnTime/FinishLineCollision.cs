using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollision : MonoBehaviour
{
    public bool hasArrived = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        hasArrived = true;
        AudioSource audioSource = GameObject.Find("GameController").GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.PlayOneShot(StaticGameData.winSoundEffect, 1F);
        StaticGameData.Game.Points++;
        StartCoroutine(StaticGameData.swapScene());
    }
}
