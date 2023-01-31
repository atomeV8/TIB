using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerAOT : MonoBehaviour
{
    //GameObjects
    GameObject leftArrowUp;
    GameObject leftArrowDown;
    GameObject rightArrowUp;
    GameObject rightArrowDown;
    GameObject character;
    Text timerDisplay;
    //Input management
    bool leftWasPressed = false;
    bool rightWasPressed = false;
    //Timer management
    [SerializeField]
    private float countDownLength = 10;
    public bool timerIsRunning = false;
    //Collision
    FinishLineCollision characterScript;
    bool hasLost = false;

    // Start is called before the first frame update
    void Start()
    {
        leftArrowUp = GameObject.Find("LeftArrowKey");
        leftArrowDown = GameObject.Find("LeftArrowKeyDown"); 
        rightArrowUp = GameObject.Find("RightArrowKey");
        rightArrowDown = GameObject.Find("RightArrowKeyDown");
        character = GameObject.Find("Character");
        timerDisplay = GameObject.Find("Canvas/TimerDisplay").GetComponent<Text>();
        leftArrowDown.SetActive(false);
        rightArrowDown.SetActive(false);
        timerIsRunning = true;
        characterScript = character.GetComponent<FinishLineCollision>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterScript.hasArrived)
        {
            timerIsRunning = false;
        }
        if (timerIsRunning && !characterScript.hasArrived)
        {

            //Charachter's movement
            if (rightWasPressed && leftWasPressed)
            {
                character.transform.position = new Vector3(character.transform.position.x + 0.2f, character.transform.position.y);

                rightWasPressed = false;
                leftWasPressed = false;
            }
        }

        //Timer
        if (timerIsRunning)
        {
            if (Mathf.Round(countDownLength) > 0)
            {
                countDownLength -= Time.deltaTime;
                timerDisplay.text = Mathf.Round(countDownLength) + " secondes" ;
            }
            else if(!hasLost)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
                hasLost = true;
                //IL PERD ICI
                timerIsRunning = false;
                rightArrowUp.SetActive(true);
                rightArrowDown.SetActive(false);
                leftArrowUp.SetActive(true);
                leftArrowDown.SetActive(false);

                StaticGameData.isLost = true;
                StartCoroutine(StaticGameData.swapScene());
            }
        }
    }

    private void OnGUI()
    {
        switch (Event.current.keyCode)
        {
            case KeyCode.LeftArrow:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    leftWasPressed = true;

                    leftArrowUp.SetActive(false);
                    leftArrowDown.SetActive(true);
                }
                else
                {
                    leftArrowUp.SetActive(true);
                    leftArrowDown.SetActive(false);
                }
                break;
            case KeyCode.RightArrow:
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    rightWasPressed = true;

                    rightArrowUp.SetActive(false);
                    rightArrowDown.SetActive(true);
                }
                else
                {
                    rightArrowUp.SetActive(true);
                    rightArrowDown.SetActive(false);
                }
                break;
        }
    }
}
