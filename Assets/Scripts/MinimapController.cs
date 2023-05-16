using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    GameObject[] mapPoints = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {
        mapPoints[0] = GameObject.Find("MapPointInfo");
        mapPoints[1] = GameObject.Find("MapPointBT");
        mapPoints[2] = GameObject.Find("MapPointMeca");
        mapPoints[3] = GameObject.Find("MapPointElectro");
        mapPoints[4] = GameObject.Find("MapPointAuto");
        mapPoints[5] = GameObject.Find("MapPointMultimedia");
        mapPoints[6] = GameObject.Find("MapPointDehors");

        foreach (Object obj in mapPoints)
        {
            Debug.Log(obj.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCharacterPosition()
    {
        this.gameObject.transform.position.x = mapPoints[0].gameObject.transform.position.x;
    }
}
