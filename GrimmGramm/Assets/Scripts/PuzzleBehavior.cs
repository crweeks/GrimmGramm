﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBehavior : MonoBehaviour
{
    public List<Piece> Pieces;
    public List<float[]> Answers;
    public float[] Ans_X;
    public float[] Ans_Y;
    public int[] Ans_Rotation;
    public int[] Ans_Shape;
    public bool ActiveSelection;
    public Piece Selected;
    private Vector3 SelectedOffset;
    public bool Completed = false;
    private bool nextTrigger = false;
    private float startFade = 0;
    private float winFade = 0;
    private float endFade = 0;
    public GameObject VictoryImage;
    public GameObject Outline;
    public PuzzleMaker parent;

    void Start()
    {
        ActiveSelection = false;
        foreach(Piece p in Pieces){
            p.Parent = this;
            p.SetRotate(p.PieceRotation);
        }
    }

    void Update()
    {
        if(ActiveSelection && !Completed){
            Selected.MoveTo(getMouse() + SelectedOffset);
        }

        if (Input.GetMouseButtonDown(1) && !Completed)
        {
            if(Selected != null){
                Selected.IncRotate();
                bool correct = CheckAnswers();
                if (correct) TriggerVictory();
            }
        }

        
        if (Completed){
            winFade += Time.deltaTime;
            foreach (Piece p in Pieces){
                FadeCalc(p.gameObject, 1, 0, winFade / parent.win_transition_length);
            }
            FadeCalc(VictoryImage, 0, 1, winFade / parent.win_transition_length);
            FadeCalc(Outline, 0.5f, 0, winFade / parent.win_transition_length);

            if(winFade > parent.win_transition_length && !nextTrigger)
            {
                nextTrigger = true;
                parent.nextLevel();
            }

            if (winFade > parent.win_transition_length + parent.level_transition_delay)
            {
                endFade += Time.deltaTime;
                FadeCalc(parent.FadeCover, 0, 1, 2 * endFade / parent.level_transition_length);
            }
        }
        else
        {
            startFade += Time.deltaTime;
            FadeCalc(parent.FadeCover, 1, 0, 2 * startFade / parent.level_transition_length);
        }
    }

    public bool CheckAnswers(){
        int num_correct = 0;
        for(int a = 0; a < Ans_Shape.Length; a += 1){
            bool right = false;
            foreach(Piece p in Pieces){
                if(p.shape != Ans_Shape[a]) continue;
                if (System.Math.Abs(p.transform.position.x - Outline.transform.position.x - Ans_X[a]) > 0.25) continue;
                if(System.Math.Abs(p.transform.position.y - Outline.transform.position.y - Ans_Y[a]) > 0.25) continue;
                
                if(p.PieceRotation != Ans_Rotation[a] && p.shape != 0 && p.shape != 4) continue;
                if(p.PieceRotation % 2 != Ans_Rotation[a]  && p.shape == 0) continue;
                if(p.PieceRotation % 4 != Ans_Rotation[a] && p.shape == 4) continue;

                right = true;
            }
            if(right){
                num_correct += 1;
            }
        }
        print("Correct: " + num_correct.ToString());
        return num_correct == Ans_Shape.Length;
    }

    public Vector3 getMouse(){
        Vector3 newMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(newMouse.x, newMouse.y, 0);
    }

    public void Select(Piece p){
        ActiveSelection = true;
        Selected = p;
        SelectedOffset = Selected.transform.position - getMouse();
    }

    public void Deselect(Piece p){
        ActiveSelection = false;
        bool correct = CheckAnswers();
        if(correct) TriggerVictory();
    }

    public void TriggerVictory(){
        Completed = true;
        winFade = 0;
    }

    private void FadeCalc(GameObject gameObject, float st, float fi, float ft){
        Color c = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, Mathf.Lerp(st, fi, ft));
    }
}
