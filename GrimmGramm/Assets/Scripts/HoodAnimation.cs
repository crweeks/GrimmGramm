using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodAnimation : PuzzleAnimation
{
    public GameObject BackCover;
    public GameObject Hood;
    private Vector3 HoodPosition;
    private float t = 0;

    public void StartAnimation()
    {

    }

    void Start()
    {
        HoodPosition = Hood.transform.position;
    }

    void Update()
    {
        //print(running);
        if (running)
        {
            t += Time.deltaTime;
            if (t < 1)
            {
                //Show full image
            }
            else if (t < 2)
            {
                FadeCalc(Hood, 1f, 0, (t - 1f));
            }
            else if (t < 4f)
            {
                Hood.transform.position = new Vector3(-4.5f, -1f, 0);
                Hood.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

                FadeCalc(Hood, 0f, 1f, (t - 2f));
            }
            else if (t < 5)
            {
                FadeCalc(Hood, 1f, 0f, (t - 4f));
            }
            else if (t < 7)
            {
                Hood.transform.position = new Vector3(0f, 0f, 0);
                Hood.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

                FadeCalc(Hood, 0f, 1f, (t - 5f));
            }
            else if (t < 8f)
            {
                FadeCalc(Hood, 1f, 0f, (t - 7f));
            }
            else if (t < 10f)
            {
                Hood.transform.position = new Vector3(4.5f, 1f, 0);
                Hood.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);

                FadeCalc(Hood, 0f, 1f, (t - 8f));
            }
            else
            {
                FadeCalc(Hood, 1f, 0f, (t - 10f));
            }
            if (t > 11f) running = false;
        }
    }
}
