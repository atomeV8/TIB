using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private BoxCollider2D topWall;
    [SerializeField]
    private BoxCollider2D bottomWall;
    [SerializeField]
    private BoxCollider2D leftWall;
    [SerializeField]
    private BoxCollider2D leftWall2;
    [SerializeField]
    private BoxCollider2D rightWall;
    [SerializeField]
    private BoxCollider2D winDetection;
    [SerializeField]
    private Transform Player01;

    // Start is called before the first frame update
    void Start()
    {
        topWall.size = new Vector2(Screen.width + 2f, 1f);
        topWall.offset = new Vector2(0, -0.2f);

        bottomWall.size = new Vector2(Screen.width + 2f, 1f);
        bottomWall.offset = new Vector2(0, -5f);

        leftWall.size = new Vector2(1f, Screen.height + 2f);
        leftWall.offset = new Vector2(-6.5f, -2f);

        leftWall2.size = new Vector2(1f, 3f);
        leftWall2.offset = new Vector2(-2.5f, -1f);

        rightWall.size = new Vector2(1f, Screen.height + 2f);
        rightWall.offset = new Vector2(4f, -2f);

        winDetection.size = new Vector2(0.25f, 1f);
        winDetection.offset = new Vector2(-2.6f, -0.5f);

        Player01.position.Set(-2f, 0.8f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
