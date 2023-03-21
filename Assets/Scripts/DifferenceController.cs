using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferenceController : MonoBehaviour
{
    [SerializeField]
    GameObject TileContainer;

    GameObject[] tiles = new GameObject[4];

    private Sprite goodSprite;
    private Sprite wrongSprite;
    void Start()
    {
        StaticGameData.Game.inMinigame = true;
        int folderNb = Random.Range(0, 4);
        goodSprite = Resources.Load<Sprite>("Memory/"+ folderNb + "/good") as Sprite;
        wrongSprite = Resources.Load<Sprite>("Memory/"+ folderNb + "/bad") as Sprite;

        int wrongOne = Random.Range(0, 3);
        ///Fetching the gameobjects
        for (int i = 0; i < 4; i++)
        {
            tiles[i] = TileContainer.transform.GetChild(i).gameObject;
            if(i == wrongOne)
            {
                //tiles[i].GetComponent<Image>().color = new Color(255, 0, 0);
                tiles[i].GetComponent<Image>().sprite = wrongSprite;
                tiles[i].name = "Intruder";
            }
            else
            {
                tiles[i].name = "Normal";
                tiles[i].GetComponent<Image>().sprite = goodSprite;
            }
        }

        tiles[0].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[0]); });
        tiles[1].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[1]); });
        tiles[2].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[2]); });
        tiles[3].GetComponent<Button>().onClick.AddListener(() => { onClickListener(tiles[3]); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onClickListener(GameObject button)
    {
        if(button.name == "Intruder")
        {
            //Jeu gagne
            StaticGameData.Game.Points++;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(StaticGameData.winSoundEffect, 1F);
            button.GetComponent<Image>().color = new Color32(0, 255, 0, 80);
        }
        else
        {
            //Jeu perdu
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(StaticGameData.lossSoundEffect, 1F);
            button.GetComponent<Image>().color = new Color32(255, 0, 0, 80);
            StaticGameData.isLost = true;
        }

        StartCoroutine(StaticGameData.swapScene());
    }
}
