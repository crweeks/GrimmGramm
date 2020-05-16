using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public PuzzleBehavior Parent;
    public Color PieceColor;
    private Vector3 StartPosition;
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
    }

    void Update()
    {
        
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
}
