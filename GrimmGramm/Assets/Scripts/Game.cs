using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    
    public List<Piece> Pieces;
    public List<float[]> Answers;
    public bool ActiveSelection;
    public Piece Selected;
    public Vector3 SelectedOffset;
    public bool Completed = false;
    public float fadeTime;
    public GameObject VictoryImage;
    public GameObject Outline;

    void Start()
    {
        ActiveSelection = false;
        foreach(Piece p in Pieces){
            p.Parent = this;
            p.SetRotate(p.PieceRotation);
        }

        Answers = new List<float[]>();
        Answers.Add(new float[]{-5.24f, -2.76f, 0, 0});
        Answers.Add(new float[]{-4.85f, -2.04f, 0, 4});
        Answers.Add(new float[]{-3.97f, -1.93f, 6, 1});
        Answers.Add(new float[]{-1.17f, -0.60f, 7, 1});
        Answers.Add(new float[]{-3.49f, -1.43f, 5, 2});
        Answers.Add(new float[]{-2.50f, -1.40f, 4, 3});
        Answers.Add(new float[]{-1.56f, -1.08f, 0, 3});
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
                print("rotate");
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
        bool wrong = false;
        foreach(float[] a in Answers){
            bool right = false;
            foreach(Piece p in Pieces){
                if(p.shape != a[3]) continue;
                if(System.Math.Abs(p.transform.position.x - a[0]) > 0.25) continue;
                if(System.Math.Abs(p.transform.position.y - a[1]) > 0.25) continue;
                
                if(p.PieceRotation != a[2] && (p.shape == 1 || p.shape == 2 || p.shape == 3)) continue;
                if(p.PieceRotation % 2 != a[2]  && p.shape == 0) continue;
                if(p.PieceRotation % 4 != a[2] && p.shape == 4) continue;

                right = true;
            }
            if(right == false){
                wrong = true;
                print(a[3]);
                break;
            }
        }
        return !wrong;
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
