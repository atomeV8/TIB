using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private KeyCode moveUp;
    [SerializeField]
    private KeyCode moveDown;
    [SerializeField]
    private KeyCode moveRight;
    [SerializeField]
    private KeyCode moveLeft;
    private float moveX = 0;
    private float moveY = 0;
    private Rigidbody2D rigBody;

    private AudioSource ads1;
    private AudioSource ads2;

    private AudioSource lathe;

    [SerializeField]
    private GameObject piece;
    private pieceVelocity collision;

    [SerializeField]
    private float timeRemaining = 0.0f;

    private bool isInTolerance = false;
    private bool isTooFar = false;
    private bool perdu = false;
    bool hasWon = false;

    void Awake()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ads1 = GetComponents<AudioSource>()[0];
        ads2 = GetComponents<AudioSource>()[1];
        collision = piece.GetComponent<pieceVelocity>();

        lathe = GetComponent<AudioSource>();
        lathe.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            moveY = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            moveY = -speed;
        }
        else
        {
            moveY = 0;
        }

        if (Input.GetKey(moveRight))
        {
            moveX = speed;
        }
        else if (Input.GetKey(moveLeft))
        {
            moveX = -speed;
        }
        else
        {
            moveX = 0;
        }
        if((moveX == 0 || moveY == 0) && !collision.borderCollision)
        {
            rigBody.velocity = new Vector2(moveX, moveY);
        }
        else
        {
            rigBody.velocity = new Vector2(0, 0);
            if(collision.borderCollision)
            {
                perdu = true;
            }
        }

        if(moveX == 0  && moveY == 0 && isInTolerance && !perdu && !hasWon)
        {
            ads1.Stop();
            ads2.Stop();
            ads2.PlayOneShot(StaticGameData.winSoundEffect, 0.5f);
            hasWon = true;
            print("Gagne");                                                                                         //Gagné
            StaticGameData.Game.Points++;
            StartCoroutine(StaticGameData.swapScene());
        }


        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            perdu = true;                                                                                    
        }

        if(isTooFar)
        {
            perdu = true;                                                                                      
        }

        if(perdu)
        {
            ads1.Stop();
            ads2.Stop();
            ads2.PlayOneShot(StaticGameData.lossSoundEffect, 0.5f);
            print("Perdu");                                                                                         //Perdu
            StaticGameData.isLost = true;
            StartCoroutine(StaticGameData.swapScene());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tolerance")
        {
            print("is in tolerance");
            isInTolerance = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tolerance")
        {
            print("You fucked up the part");
            isTooFar = true;
        }
    }
}
