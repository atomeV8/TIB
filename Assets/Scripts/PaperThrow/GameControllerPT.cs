using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerPT : MonoBehaviour
{
    //GameObjects
    Text timerDisplay;
    GameObject aimIndicator;
    GameObject paperBall;
    GameObject trashcan;
    //Timer management
    [SerializeField]
    private float countDownLength = 10;
    private bool timerIsRunning = true;
    //Aim rotation management
    [SerializeField]
    private float rotationSpeed = 0.0f;
    bool rotationSens = false;
    public bool isAiming = true;
    //Throw management
    [SerializeField]
    private float throwPower;
    //
    BallEnters ballEnters;
    bool hasLost = false;


    // Start is called before the first frame update
    void Start()
    {
        aimIndicator = GameObject.Find("AimIndicator");
        trashcan = GameObject.Find("Trashcan");
        timerDisplay = GameObject.Find("Canvas/TimerDisplay").GetComponent<Text>();
        paperBall = GameObject.Find("PaperBall");
        paperBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        ballEnters = trashcan.GetComponent<BallEnters>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning && ballEnters.ballEntered==false)
        {
            //Aim rotation
            if (isAiming)
            {
                if (rotationSens)
                {
                    aimIndicator.transform.Rotate(new Vector3(0, 0, rotationSpeed));
                }
                else
                {
                    aimIndicator.transform.Rotate(new Vector3(0, 0, -rotationSpeed));
                }
                int angle = Mathf.RoundToInt(aimIndicator.transform.rotation.eulerAngles.z);
                if (angle <= 270)
                {
                    rotationSens = !rotationSens;
                }
            }
            //Timer
            if (Mathf.Round(countDownLength) > 0)
            {
                countDownLength -= Time.deltaTime;
                timerDisplay.text = Mathf.Round(countDownLength) + " secondes";
            }
            else if(!hasLost)
            {
                hasLost = true;
                print("lose");
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
                //FIN DU TIMER = DEFAITE
                //ICI IL PERD
                StaticGameData.isLost = true;
                StartCoroutine(StaticGameData.swapScene());
                timerIsRunning = false;
            }
        }
    }

    private void OnGUI()
    {
        switch (Event.current.keyCode)
        {
            case KeyCode.Space:
                if (isAiming)
                {
                    launchPaperBall();
                    isAiming = false;
                }
                break;
        }
    }

    private void launchPaperBall()
    {
        float angle = 360 - (Mathf.Round(aimIndicator.transform.rotation.eulerAngles.z));
        float x = -(Mathf.Cos(Mathf.Deg2Rad * angle) * throwPower);
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * throwPower;
        print("angle = " + angle);
        print("valeur x = " + x);
        print("valeur y = " + y);
        Rigidbody2D paperBallRigidbody = paperBall.GetComponent<Rigidbody2D>();
        paperBallRigidbody.bodyType = RigidbodyType2D.Dynamic;
        paperBallRigidbody.velocity = new Vector2(x, y);
    }
}
