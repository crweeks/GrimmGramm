using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelMover : MonoBehaviour
{
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;
    public GameObject Level6;
    public GameObject Level7;
    public GameObject Level8;
    public GameObject Level9;

    private Vector3 Pos1;
    private Vector3 Pos2;
    private Vector3 Pos3;
    private Vector3 Pos4;
    private Vector3 Pos5;
    private Vector3 Pos6;
    private Vector3 Pos7;
    private Vector3 Pos8;
    private Vector3 Pos9;

    private float T;

    void Start()
    {
        T = 0f;

        Pos1 = Level1.GetComponent<RectTransform>().localPosition;
        Pos2 = Level2.GetComponent<RectTransform>().localPosition;
        Pos3 = Level3.GetComponent<RectTransform>().localPosition;
        Pos4 = Level4.GetComponent<RectTransform>().localPosition;
        Pos5 = Level5.GetComponent<RectTransform>().localPosition;
        Pos6 = Level6.GetComponent<RectTransform>().localPosition;
        Pos7 = Level7.GetComponent<RectTransform>().localPosition;
        Pos8 = Level8.GetComponent<RectTransform>().localPosition;
        Pos9 = Level9.GetComponent<RectTransform>().localPosition;
    }

    void Update()
    {
        T += Time.deltaTime;
        float v1 = 10 * Convert.ToSingle(Math.Cos(T + 1));
        float v2 = 10 * Convert.ToSingle(Math.Cos(T + 2));
        float v3 = 10 * Convert.ToSingle(Math.Cos(T + 3));
        Level1.GetComponent<RectTransform>().localPosition = new Vector3(Pos1.x, Pos1.y + v1, 0);
        Level2.GetComponent<RectTransform>().localPosition = new Vector3(Pos2.x, Pos2.y + v2, 0);
        Level3.GetComponent<RectTransform>().localPosition = new Vector3(Pos3.x, Pos3.y + v3, 0);
        Level4.GetComponent<RectTransform>().localPosition = new Vector3(Pos4.x, Pos4.y + v1, 0);
        Level5.GetComponent<RectTransform>().localPosition = new Vector3(Pos5.x, Pos5.y + v2, 0);
        Level6.GetComponent<RectTransform>().localPosition = new Vector3(Pos6.x, Pos6.y + v3, 0);
        Level7.GetComponent<RectTransform>().localPosition = new Vector3(Pos7.x, Pos7.y + v1, 0);
        Level8.GetComponent<RectTransform>().localPosition = new Vector3(Pos8.x, Pos8.y + v2, 0);
        Level9.GetComponent<RectTransform>().localPosition = new Vector3(Pos9.x, Pos9.y + v3, 0);
    }
}
