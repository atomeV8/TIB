using UnityEngine;

public class MinimapController : MonoBehaviour
{
    GameObject[] mapPoints = new GameObject[8];
    Vector2 posFinal;
    Vector2 chemin;
    int step = 0;
    int stepsUntilFinished = 80;
    float frameRate = 60f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posFinal = new Vector3();

        mapPoints[1] = GameObject.Find("MapPointInfo");
        mapPoints[2] = GameObject.Find("MapPointBT");
        mapPoints[3] = GameObject.Find("MapPointMeca");
        mapPoints[4] = GameObject.Find("MapPointElectro");
        mapPoints[5] = GameObject.Find("MapPointAuto");
        mapPoints[6] = GameObject.Find("MapPointMultimedia");
        mapPoints[7] = GameObject.Find("MapPointDehors");
        chemin = new Vector2();
        Time.fixedDeltaTime = 1f / frameRate;

        if (PlayerPrefs.GetInt("MapPosition") == 0)
        {
            PlayerPrefs.SetInt("MapPosition", 7);
        }

        gameObject.transform.position = mapPoints[PlayerPrefs.GetInt("MapPosition")].transform.position;

        setCharacterPosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (step < stepsUntilFinished)
        {
            //Debug.Log(chemin);
            rb.MovePosition(rb.position + chemin);
            step++;
        }
    }

    public void setCharacterPosition()
    {
        int spot;
        while (true)
        {
            spot = Random.Range(1, 8);

            if (spot != PlayerPrefs.GetInt("MapPosition"))
            {
                posFinal.x = mapPoints[spot].gameObject.transform.position.x;
                posFinal.y = mapPoints[spot].gameObject.transform.position.y;
                chemin.x = (posFinal.x - gameObject.transform.position.x) / stepsUntilFinished;
                chemin.y = (posFinal.y - gameObject.transform.position.y) / stepsUntilFinished;
                PlayerPrefs.SetInt("MapPosition", spot);
                return;
            }
        }


    }
}
