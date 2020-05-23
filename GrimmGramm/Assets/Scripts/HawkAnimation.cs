using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkAnimation : PuzzleAnimation
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
            //else if (t < 2)
            //{
            //    FadeCalc(BackCover, 0.25f, 0, (t - 1f) * 2);
            //}
            else if (t < 3)
            {
                //var time = Mathf.Hermite(0.0, 1.0, (t - 1f) / 2);
                float time = Mathf.SmoothStep(0.0f, 1.0f, (t - 1f) / 2.0f);
                float newScale = Mathf.Lerp(1.0f, 0.45f, time);
                Hawk.transform.localScale = new Vector3(newScale, newScale, 1.0f);

                float newX = Mathf.Lerp(HawkPosition.x, -7.31f, time);
                float newY = Mathf.Lerp(HawkPosition.y, 1.99f, time);
                Hawk.transform.position = new Vector3(newX, newY, 0);
            }
            if (t > 4) running = false;
        }
    }
}
