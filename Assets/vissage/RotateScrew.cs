using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScrew : MonoBehaviour
{
    private const int Up = 1;
    private const int Right = 2;
    private const int Down = 3;
    private const int Left = 4;

    private int position = Up;

    private AudioSource screwdriver;
    private AudioSource music;

    [SerializeField]
    private KeyCode keyW;
    [SerializeField]
    private KeyCode keyA;
    [SerializeField]
    private KeyCode keyS;
    [SerializeField]
    private KeyCode keyD;

    [SerializeField]
    private GameObject screw;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite arrowU;
    [SerializeField]
    private Sprite arrowD;
    [SerializeField]
    private Sprite arrowR;
    [SerializeField]
    private Sprite arrowL;

    private int rotation = 0;
    private int rotationEnd = 0;

    private float timeConst = 0.0f;
    [SerializeField]
    private float incrementTime;


    bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        screwdriver = GetComponents<AudioSource>()[0];
        music = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasWon)
        {
            if (Input.GetKey(keyD) && position == Up && !Input.GetKey(keyA) && !Input.GetKey(keyS) && !Input.GetKey(keyW))
            {
                screwdriver.Play();
                rotationEnd += 90;
                print("D");
                position = Right;
                ChangeSprite(3);
            }

            if (Input.GetKey(keyS) && position == Right && !Input.GetKey(keyA) && !Input.GetKey(keyD) && !Input.GetKey(keyW))
            {
                screwdriver.Play();
                rotationEnd += 90;
                print("S");
                position = Down;
                ChangeSprite(4);
            }

            if (Input.GetKey(keyA) && position == Down && !Input.GetKey(keyS) && !Input.GetKey(keyW) && !Input.GetKey(keyD))
            {
                screwdriver.Play();
                rotationEnd += 90;
                print("A");
                position = Left;
                ChangeSprite(1);
            }

            if (Input.GetKey(keyW) && position == Left && !Input.GetKey(keyA) && !Input.GetKey(keyS) && !Input.GetKey(keyD))
            {
                screwdriver.Play();
                rotationEnd += 90;
                print("W");
                position = Up;
                ChangeSprite(2);
            }

            if (rotation < rotationEnd)
            {
                timeConst += Time.deltaTime;
                if (timeConst > incrementTime && !hasWon)
                {
                    screw.transform.Rotate(0f, 0f, -8f);
                    rotation += 8;
                    timeConst = 0.0f;
                }
            }
        }
        if(rotation >= 1800 && !hasWon)
        {
            music.Stop();
            music.PlayOneShot(StaticGameData.winSoundEffect, 0.5f);
            hasWon = true;
            StaticGameData.Game.Points++;
            StartCoroutine(StaticGameData.swapScene());
        }
    }

    public void ChangeSprite(int orientation)
    {
        switch (orientation)
        {
            case 1:
                spriteRenderer.sprite = arrowU;
                break;
            case 2:
                spriteRenderer.sprite = arrowR;
                break;
            case 3:
                spriteRenderer.sprite = arrowD;
                break;
            case 4:
                spriteRenderer.sprite = arrowL;
                break;
        }
    }
}
