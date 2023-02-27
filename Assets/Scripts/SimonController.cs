using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonController : MonoBehaviour
{
    [SerializeField]
    private GameObject TileContainer;
    [SerializeField]
    private int difficulty = 5;

    System.Random rdn = new System.Random();

    private GameObject[] tiles = new GameObject[4];

    private Color32[] colors = new Color32[4];
    private Color32[] fadingColors = new Color32[4];

    private List<int> sequence = new List<int>();
    private bool sequenceFase = true;
    private bool gameIsEnd = false;
    private int actualSequenceItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        StaticGameData.Game.inMinigame = true;

        ///Initializing the colors
        colors[0] = new Color32(255, 0, 0, 100);
        colors[1] = new Color32(0, 255, 0, 100);
        colors[2] = new Color32(0, 0, 255, 100);
        colors[3] = new Color32(255, 255, 0, 100);

        fadingColors[0] = new Color32(255, 0, 0, 20);
        fadingColors[1] = new Color32(0, 255, 0, 20);
        fadingColors[2] = new Color32(0, 0, 255, 20);
        fadingColors[3] = new Color32(255, 255, 0, 20);

        ///Fetching the gameobjects
        for (int i = 0; i < 4; i++)
        {
            tiles[i] = TileContainer.transform.GetChild(i).gameObject;
            tiles[i].GetComponent<Image>().color = fadingColors[i];

            tiles[i].name = i.ToString();
        }

        tiles[0].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[0]); });
        tiles[1].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[1]); });
        tiles[2].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[2]); });
        tiles[3].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[3]); });

        ///Preparing the sequence
        for (int i = 0; i <= difficulty; i++)
        {
            int sequenceItem = rdn.Next(0, 4);
            sequence.Add(sequenceItem);
        }

    }

    private void resetColors()
    {
        for (int i = 0; i < 4; i++)
        {
            tiles[i].GetComponent<Image>().color = fadingColors[i];
        }
    }

    public void onClickListener(GameObject button)
    {
        if (!gameIsEnd)
        {
            if (sequenceFase == false)
            {
                resetColors();
                button.GetComponent<Image>().color = colors[int.Parse(button.name)];
                if (actualSequenceItem == 5)
                {
                    goodEnd();
                    StartCoroutine(StaticGameData.swapScene());
                }

                if (sequence[actualSequenceItem] == int.Parse(button.name))
                {
                    actualSequenceItem++;
                }
                else
                {
                    StaticGameData.isLost = true;
                    badEnd();
                    StartCoroutine(StaticGameData.swapScene());
                }
            }
        }
    }

    private void badEnd()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
        gameIsEnd = true;
        tiles[0].GetComponent<Image>().color = colors[0];
        tiles[1].GetComponent<Image>().color = colors[0];
        tiles[2].GetComponent<Image>().color = colors[0];
        tiles[3].GetComponent<Image>().color = colors[0];
    }

    private void goodEnd()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(StaticGameData.winSoundEffect, 0.5f);
        StaticGameData.Game.Points++;
        gameIsEnd = true;
        tiles[0].GetComponent<Image>().color = colors[1];
        tiles[1].GetComponent<Image>().color = colors[1];
        tiles[2].GetComponent<Image>().color = colors[1];
        tiles[3].GetComponent<Image>().color = colors[1];
    }

    private float elapsed = 0f;
    private bool pause = false;
    void Update()
    {
        if (sequenceFase)
        {
            elapsed += Time.deltaTime;
            if (pause)
            {
                if (elapsed >= 0.5f)
                {
                    elapsed = elapsed % 1f;
                    ReadSequence();
                    pause = !pause;
                }
            }
            else
            {
                if (elapsed >= 1f)
                {
                    elapsed = elapsed % 1f;
                    resetColors();
                    pause = !pause;
                }
            }
        }
    }

    private int sequenceNumber = 0;
    private void ReadSequence()
    {
        resetColors();
        if (sequenceNumber < sequence.Count)
        {
            switch (sequence[sequenceNumber])
            {
                case 0:
                    tiles[0].GetComponent<Image>().color = colors[0];
                    break;
                case 1:
                    tiles[1].GetComponent<Image>().color = colors[1];
                    break;
                case 2:
                    tiles[2].GetComponent<Image>().color = colors[2];
                    break;
                case 3:
                    tiles[3].GetComponent<Image>().color = colors[3];
                    break;
            }
            sequenceNumber++;
        }
        else
        {
            sequenceFase = false;
        }
    }
}
