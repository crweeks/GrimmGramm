using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : PuzzleAnimation
{
    public GameObject FrontCover;
    public GameObject BackCover;
    public GameObject Wolf;
    public GameObject Eyes;
    public GameObject Hawk;
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
                //FadeCalc(BackCover, 0.25f, 0, t);
                FadeCalc(Hawk, 1f, 0, t);
            }
            else if (t < 4)
            {
                float time = Mathf.SmoothStep(0.0f, 1.0f, (t - 1f) / 3.0f);
                float newScale = Mathf.Lerp(1.0f, 3.5f, time);
                Wolf.transform.localScale = new Vector3(newScale, newScale, 1.0f);
                Eyes.transform.localScale = new Vector3(newScale, newScale, 1.0f);

                float newX = Mathf.Lerp(WolfPosition.x, -8.0f, time);
                float newY = Mathf.Lerp(WolfPosition.y, 0.14f, time);
                Wolf.transform.position = new Vector3(newX, newY, 0.0f);
                Eyes.transform.position = new Vector3(newX, newY, 0.0f);
            }
            else if (t < 5)
            {

            }
            else if (t < 7)
            {
                FadeCalc(FrontCover, 0f, 1f, (t - 5f) / 2);

                FadeCalc(Eyes, 0f, 1f, (t - 5f) / 2);
            }
            if (t > 8) running = false;
        }
    }
}
