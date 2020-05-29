using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodAnimation : PuzzleAnimation
{
    public GameObject BackCover;
    public GameObject Hood;
    public GameObject Hawk;
    public GameObject Tree1;
    public GameObject Tree2;

    private Vector3 HoodPosition;
    private float t = 0;
    private bool stillgoing;

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
        if (running || stillgoing)
        {
            stillgoing = true;
            t += Time.deltaTime;
            if (t < 1)
            {
                //FadeCalc(BackCover, 0.25f, 0, t);
                FadeCalc(Hawk, 1f, 0, t);
            }
            else if (t < 7)
            {
                float time = Mathf.SmoothStep(0.0f, 1.0f, (t - 1f) / 6.0f);
                float newScale = Mathf.Lerp(2.0f, 1.0f, time);

                Hood.transform.localScale = new Vector3(newScale, newScale, 1.0f);
                float newX = Mathf.Lerp(HoodPosition.x, 0f, time);
                float newY = Mathf.Lerp(HoodPosition.y, 0f, time);
                Hood.transform.position = new Vector3(newX, newY, 0.0f);

                float newScale2 = Mathf.Lerp(1.0f, 2.0f, time);
                Tree1.transform.localScale = new Vector3(newScale2, newScale2, 1.0f);
                Tree2.transform.localScale = new Vector3(newScale2, newScale2, 1.0f);

                float newX1 = Mathf.Lerp(0.07f, 7.36f, time);
                float newY1 = Mathf.Lerp(-0.05f, -2.66f, time);
                Tree1.transform.position = new Vector3(newX1, newY1, 0.0f);

                float newX2 = Mathf.Lerp(-0.12f, -6.04f, time);
                float newY2 = Mathf.Lerp(0f, 2.96f, time);
                Tree2.transform.position = new Vector3(newX2, newY2, 0.0f);
            }
            if (t > 6.0f) running = false;
        }
    }
}
