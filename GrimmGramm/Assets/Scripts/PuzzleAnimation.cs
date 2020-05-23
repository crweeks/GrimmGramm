using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleAnimation : MonoBehaviour
{

    public bool running;

    public void StartAnimation()
    {
        running = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FadeCalc(GameObject gameObject, float st, float fi, float ft)
    {
        Color c = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, Mathf.Lerp(st, fi, ft));
    }
}
