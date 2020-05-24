using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : PuzzleAnimation
{
    public GameObject FrontCover;
    public GameObject Wolf;
    public GameObject Eyes;
    private Vector3 WolfPosition;
    private float t = 0;

    public void StartAnimation()
    {

    }

    void Start()
    {
        WolfPosition = Wolf.transform.position;
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
            else if (t < 3)
            {
                FadeCalc(FrontCover, 0f, 1f, (t - 1f) / 2);

                FadeCalc(Eyes, 0f, 1f, (t - 1f) / 2);
            }
            if (t > 3) running = false;
        }
    }
}
