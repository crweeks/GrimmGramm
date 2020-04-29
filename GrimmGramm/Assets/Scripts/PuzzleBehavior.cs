using System.Collections;
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
    private float fadeTime;
    public GameObject VictoryImage;
    public GameObject Outline;

    void Start()
    {
        ActiveSelection = false;
        foreach(Piece p in Pieces){
            p.Parent = this;
            p.SetRotate(p.PieceRotation);
        }

        //Answers = new List<float[]>();
        //Answers.Add(new float[]{-5.24f, -2.76f, 0, 0});
        //Answers.Add(new float[]{-4.85f, -2.04f, 0, 4});
        //Answers.Add(new float[]{-3.97f, -1.93f, 6, 1});
        //Answers.Add(new float[]{-1.17f, -0.60f, 7, 1});
        //Answers.Add(new float[]{-3.49f, -1.43f, 5, 2});
        //Answers.Add(new float[]{-2.50f, -1.40f, 4, 3});
        //Answers.Add(new float[]{-1.56f, -1.08f, 0, 3});
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
                //print("rotate");
            }
        }

        if(Completed){
            fadeTime += Time.deltaTime;
            foreach(Piece p in Pieces){
                Fade(p.gameObject, 1, 0, fadeTime);
            }
            Fade(VictoryImage, 0, 1, fadeTime);
            Fade(Outline, 0.5f, 0, fadeTime);
        }
    }

    public bool CheckAnswers(){
        int num_correct = 0;
        for(int a = 0; a < Ans_Shape.Length; a += 1){
            bool right = false;
            foreach(Piece p in Pieces){
                if(p.shape != Ans_Shape[a]) continue;
                if (System.Math.Abs(p.transform.position.x - Ans_X[a]) > 0.25) continue;
                if(System.Math.Abs(p.transform.position.y - Ans_Y[a]) > 0.25) continue;
                
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
        fadeTime = 0;
    }

    private void Fade(GameObject gameObject, float st, float fi, float ft){
        Color c = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, Mathf.Lerp(st, fi, ft));
    }
}
