using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public PuzzleBehavior Parent;
    public Color PieceColor;
    private Vector3 StartPosition;
    private Color orig;
    private float fadeTime = 10.0f;
    public bool correct = false;
    public int PieceRotation = 0;
    public int shape;
    public int symmetry = 0;
    private bool locked = false;
    //0 = square
    //1 = small triangle
    //2 = medium triangle
    //3 = big triangle
    //4 = parallegram

    void Start()
    {
        StartPosition = transform.position;
        orig = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        if (!Parent.Completed)
        {
            if (GetComponent<SpriteRenderer>().color != orig)
            {
                fadeTime -= Time.deltaTime;
                GetComponent<SpriteRenderer>().color = Color.Lerp(orig, GetComponent<SpriteRenderer>().color, fadeTime);
                print(fadeTime);
            }
            else
            {
                fadeTime = 10.0f;
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

    public void Darken()
    {
        GetComponent<SpriteRenderer>().color = new Color(orig.r * 0.6f, orig.g * 0.6f, orig.b * 0.6f);
    }

    public void Lighten()
    {
        GetComponent<SpriteRenderer>().color = orig;
        fadeTime = 10.0f;
    }
}
