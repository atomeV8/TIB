using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    GameObject[] mapPoints = new GameObject[7];
    Vector2 posFinal;
    Vector2 chemin;
    float totalDelta;
    int step = 0;

    // Start is called before the first frame update
    void Start()
    {
        posFinal = new Vector2();
        totalDelta = new float();

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
    void Update()
    {
        totalDelta += Time.deltaTime * 1000;
        //Debug.Log(totalDelta);
        if(step < 5)
        {
            if (totalDelta >= 1000 / 24)
            {
                Vector3 newPos = new Vector3() {
                    x = this.gameObject.transform.position.x + chemin.x / 5 / 24,
                    y = this.gameObject.transform.position.y + chemin.y / 5 / 24,
                    z = 0
                };
                this.gameObject.transform.position = newPos;
                totalDelta = 0;
                step++;
            }
        }
    }

    public void setCharacterPosition(int spot)
    {
        Debug.Log(mapPoints[spot].gameObject);
        posFinal.x = mapPoints[spot].gameObject.transform.position.x;
        posFinal.y = mapPoints[spot].gameObject.transform.position.y;
        chemin.x = posFinal.x - this.gameObject.transform.position.x;
        chemin.y = posFinal.y - this.gameObject.transform.position.y;
        /*Debug.Log(mapPoints[spot].gameObject.transform.position.x);
        Debug.Log(mapPoints[spot].gameObject.transform.position.y);
        Debug.Log(chemin.x);
        Debug.Log(chemin.y);*/
    }
}
