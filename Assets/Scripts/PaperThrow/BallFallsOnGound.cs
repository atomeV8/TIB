using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFallsOnGound : MonoBehaviour
{
    GameObject paperBall;
    GameControllerPT gameControllerPT;
    // Start is called before the first frame update
    void Start()
    {
        paperBall = GameObject.Find("PaperBall");
        gameControllerPT = GameObject.Find("GameController").GetComponent<GameControllerPT>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PaperBall")
        {
            paperBall.transform.position = new Vector3(7.5f,-2f,0f);
            Rigidbody2D paperBallRigidbody = paperBall.GetComponent<Rigidbody2D>();
            paperBallRigidbody.bodyType = RigidbodyType2D.Static;
            gameControllerPT.isAiming = true;

        }
    }

}
