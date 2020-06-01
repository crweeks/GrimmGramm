using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaker : MonoBehaviour
{
    public GameObject quitButton;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject soundOnImage;
    public GameObject soundOffImage;
    public GameObject musicOnImage;
    public GameObject musicOffImage;
    public GameObject levelSelect;
    public GameObject LockControl;
    public GameObject ClickControl;
    public GameObject FinishControl;
    public GameObject MusicControl;


    public List<PuzzleBehavior> puzzles;
    public PuzzleBehavior CurrentPuzzle;
    public int currId;

    public float win_transition_length;
    public float level_transition_length;
    public float level_transition_delay;

    public GameObject FadeCover;
    public SceneManagement parent;

    public void ShowPuzzle(int puzzle_number) //Brian - Use this to create/show puzzles from main menu
    {
        currId = puzzle_number;
        print("Showing Puzzle " + puzzle_number.ToString());
        if(CurrentPuzzle != null) Destroy(CurrentPuzzle.gameObject);
        if (puzzle_number == -1)
        {
            quitButton.SetActive(false);
            soundOn.SetActive(false);
            soundOnImage.SetActive(false);
            soundOff.SetActive(false);
            soundOffImage.SetActive(false);
            musicOn.SetActive(false);
            musicOnImage.SetActive(false);
            musicOff.SetActive(false);
            musicOffImage.SetActive(false);
            Color c = FadeCover.GetComponent<SpriteRenderer>().color;
            FadeCover.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 0);
            return;
        }
        else
        {
            Color c = FadeCover.GetComponent<SpriteRenderer>().color;
            FadeCover.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 1);
            CurrentPuzzle = Instantiate(puzzles[puzzle_number], new Vector3(0, 0, 0), Quaternion.identity);
            CurrentPuzzle.parent = this;
            quitButton.SetActive(true);
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                musicOn.SetActive(true);
                musicOnImage.SetActive(true);
            }
            else
            {
                musicOff.SetActive(true);
                musicOffImage.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Mute") == 1)
            {
                soundOn.SetActive(true);
                soundOnImage.SetActive(true);
            }
            else
            {
                soundOff.SetActive(true);
                soundOffImage.SetActive(true);

            }
        }
    }

    public void nextLevel()
    {
        Invoke("nextInv", level_transition_length / 2);
    }

    public void nextInv()
    {
        currId += 1;
        if (currId >= puzzles.Count)
        {
            parent.LoadLevelSelect();
        }
        else
        {
            ShowPuzzle(currId);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
