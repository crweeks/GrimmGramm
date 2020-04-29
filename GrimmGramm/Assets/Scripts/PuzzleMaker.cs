using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaker : MonoBehaviour
{
    public List<PuzzleBehavior> puzzles;
    public PuzzleBehavior CurrentPuzzle;
    public void ShowPuzzle(int puzzle_number) //Brian - Use this to create/show puzzles from main menu
    {
        print("Showing Puzzle " + puzzle_number.ToString());
        if(CurrentPuzzle != null) Destroy(CurrentPuzzle.gameObject);
        CurrentPuzzle = Instantiate(puzzles[puzzle_number], new Vector3(0, 0, 0), Quaternion.identity);
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
