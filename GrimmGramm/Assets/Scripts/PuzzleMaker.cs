using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaker : MonoBehaviour
{
    public GameObject quitButton;
    public GameObject levelSelect;

    public List<PuzzleBehavior> puzzles;
    public PuzzleBehavior CurrentPuzzle;
    public int currId;

    public float win_transition_length;
    public float level_transition_length;
    public float level_transition_delay;

    public GameObject FadeCover;

    public void ShowPuzzle(int puzzle_number) //Brian - Use this to create/show puzzles from main menu
    {
        currId = puzzle_number;
        print("Showing Puzzle " + puzzle_number.ToString());
        if(CurrentPuzzle != null) Destroy(CurrentPuzzle.gameObject);
        if (puzzle_number == -1)
        {
            quitButton.SetActive(false);
            Color c = FadeCover.GetComponent<SpriteRenderer>().color;
            FadeCover.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 0);
            return;
        }
        else
        {
            CurrentPuzzle = Instantiate(puzzles[puzzle_number], new Vector3(0, 0, 0), Quaternion.identity);
            CurrentPuzzle.parent = this;
            quitButton.SetActive(true);
        }
    }

    public void nextLevel()
    {
        Invoke("nextInv", level_transition_delay + level_transition_length / 2);
    }

    public void nextInv()
    {
        currId += 1;
        ShowPuzzle(currId);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
