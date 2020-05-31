using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    public GameObject Back1;
    public GameObject Mid1;
    public GameObject Fore1;

    public GameObject Back2;
    public GameObject Mid2;
    public GameObject Fore2;

    private float BackPos;
    private float MidPos;
    private float ForePos;

    void Start()
    {
        print("Hello");

        BackPos = 0f;
        MidPos = 0f;
        ForePos = 0f;
        
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        Back1.GetComponent<RectTransform>().localPosition = new Vector3(BackPos, 0, 0);
        Mid1.GetComponent<RectTransform>().localPosition = new Vector3(MidPos, 0, 0);
        Fore1.GetComponent<RectTransform>().localPosition = new Vector3(ForePos, 0, 0);

        Back2.GetComponent<RectTransform>().localPosition = new Vector3(BackPos - Back2.GetComponent<RectTransform>().rect.width, 0, 0);
        Mid2.GetComponent<RectTransform>().localPosition = new Vector3(MidPos - Mid2.GetComponent<RectTransform>().rect.width, 0, 0);
        Fore2.GetComponent<RectTransform>().localPosition = new Vector3(ForePos - Fore2.GetComponent<RectTransform>().rect.width, 0, 0);
    }

    void Update()
    {
        BackPos = (BackPos + 0.6f) % Back2.GetComponent<RectTransform>().rect.width;
        MidPos = (MidPos + 0.8f) % Mid2.GetComponent<RectTransform>().rect.width;
        ForePos = (ForePos + 1.0f) % Fore2.GetComponent<RectTransform>().rect.width;

        print(Back2.GetComponent<RectTransform>().rect.width);

        UpdateDisplay();
    }
}
