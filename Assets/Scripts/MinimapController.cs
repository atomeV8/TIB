using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    GameObject[] mapPoints = new GameObject[7];
    Vector2 posFinal;
    Vector2 chemin;
    int step = 0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posFinal = new Vector3();

        mapPoints[0] = GameObject.Find("MapPointInfo");
        mapPoints[1] = GameObject.Find("MapPointBT");
        mapPoints[2] = GameObject.Find("MapPointMeca");
        mapPoints[3] = GameObject.Find("MapPointElectro");
        mapPoints[4] = GameObject.Find("MapPointAuto");
        mapPoints[5] = GameObject.Find("MapPointMultimedia");
        mapPoints[6] = GameObject.Find("MapPointDehors");

        setCharacterPosition(UnityEngine.Random.Range(0, 6));
        chemin = new Vector2();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(step < 5)
        {
                rb.MovePosition(rb.position + chemin);
                Debug.Log(rb.position);
                step++;
        }
    }

    public void setCharacterPosition(int spot)
    {
        //Debug.Log(mapPoints[spot].gameObject);
        //Debug.Log("Position du personnage avant : " + gameObject.transform.position);
        posFinal.x = mapPoints[spot].gameObject.transform.position.x;
        posFinal.y = mapPoints[spot].gameObject.transform.position.y;
        chemin.x = posFinal.x - gameObject.transform.position.x;
        chemin.y = posFinal.y - gameObject.transform.position.y;
        /*Debug.Log(mapPoints[spot].gameObject.transform.position.x);
        Debug.Log(mapPoints[spot].gameObject.transform.position.y);
        Debug.Log(chemin.x);
        Debug.Log(chemin.y);*/
    }
}
