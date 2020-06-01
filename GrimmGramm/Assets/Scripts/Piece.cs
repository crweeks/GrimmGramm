using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public PuzzleBehavior Parent;
    public Color AltColor;
    public bool useAltColor;
    private Vector3 StartPosition;
    private Color orig;
    private float fadeTime = 0.0f;
    public bool correct = false;
    public int PieceRotation = 0;
    public int shape;
    public int symmetry = 0;
    private bool locked = false;
    private Animator a;


    void Start()
    {
        StartPosition = transform.position;
        orig = GetComponent<SpriteRenderer>().color;
        a = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (!Parent.Completed)
        {
            if (fadeTime < 1)
            {
                fadeTime += Time.deltaTime;
                GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, orig, fadeTime);
            }
        }
    }

    public void SetRotate(int rot){
        PieceRotation = rot % 8;

        var euler = transform.eulerAngles;
        euler.z = PieceRotation * 45;
        transform.eulerAngles = euler;
    }

    public void IncRotate(){
        PieceRotation = (PieceRotation + 1) % 8;
        
        var euler = transform.eulerAngles;
        euler.z = PieceRotation * 45;
        transform.eulerAngles = euler;
    }

    public void MoveTo(Vector3 pos){
        transform.position = pos;
    }

    public void MoveToStart(){
        transform.position = StartPosition;
    }

    public void LockPiece(Vector3 target)
    {
        locked = true;
        transform.position = target;
        GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

    public bool IsLocked()
    {
        return locked;
    }

    void OnMouseDown()
    {
        if (!locked)
        {
            Parent.Select(this);
        }
    }

    void OnMouseUp(){
        Parent.Deselect(this);
    }

    public void Shrink()
    {
        if (a)
        {
            a.SetBool("PieceGrow", false);
            a.SetBool("PieceShrink", true);
        }
    }

    public void setOrder(int od)
    {
        GetComponent<SpriteRenderer>().sortingOrder = od;
    }

    public void Grow()
    {
        if (a)
        {
            a.SetBool("PieceGrow", true);
            a.SetBool("PieceShrink", false);
        }
    }

    public void Darken()
    {
        if (useAltColor)
        {
            GetComponent<SpriteRenderer>().color = AltColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(orig.r * 0.6f, orig.g * 0.6f, orig.b * 0.6f);
        }
        
    }

    public void Lighten()
    {
        GetComponent<SpriteRenderer>().color = orig;
        fadeTime = 0.0f;
    }
}
