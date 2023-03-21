using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceVelocity : MonoBehaviour
{

    private Rigidbody2D rigBody_Piece;

    public bool borderCollision = false;

    void Awake()
    {
        rigBody_Piece = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigBody_Piece.velocity = new Vector2(0,0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Border")
        {
            print("collision with border");
            borderCollision = true;
        }
    }
}
