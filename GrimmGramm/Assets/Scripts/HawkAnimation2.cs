using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkAnimation2 : PuzzleAnimation
{
    public GameObject BackCover;
    public GameObject Hawk;
    private Vector3 HawkPosition;
    private float t = 0;

    public void StartAnimation()
    {

    }

    void Start()
    {
        HawkPosition = Hawk.transform.position;
    }

    void Update()
    {
        //print(running);
        if (running)
        {
            t += Time.deltaTime;
            if (t < 1)
            {

            }
            else if (t < 2)
            {
                FadeCalc(Hawk, 1f, 0, (t - 1f));
            }
            else if (t < 3)
            {
                Hawk.transform.position = new Vector3(-7.31f, 1.99f, 0);
                Hawk.transform.localScale = new Vector3(0.45f, 0.45f, 1.0f);

                FadeCalc(Hawk, 0f, 1f, (t - 2f));
            }
            if (t > 4) running = false;
        }
    }
}
