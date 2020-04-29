using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public PuzzleBehavior Parent;
    private Vector3 StartPosition;
    public int PieceRotation = 0;
    public int shape;
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

    void OnMouseDown(){
        Parent.Select(this);
        print("Test");
    }

    void OnMouseUp(){
        Parent.Deselect(this);
    }
}
