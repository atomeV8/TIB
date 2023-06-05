using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{
    Animator animator;
    private float cooldownTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play("DIdle");
        cooldownTime -= Time.deltaTime;
        if(cooldownTime < 0)
        {
            SceneManager.LoadScene("EndingScreen");
            SceneManager.UnloadSceneAsync("DirectorAngry");
        }
    }
}
