using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    GameObject active;
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject levelSelect;
    public PuzzleMaker puzzleMaker;

    // Start is called before the first frame update
    void Start()
    {
        puzzleMaker.parent = this;
        active = mainMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        active.SetActive(false);
        active = mainMenu;
        active.SetActive(true);
    }

    public void LoadSettings()
    {
        active.SetActive(false);
        active = settings;
        active.SetActive(true);
    }

    public void LoadLevelSelect()
    {
        active.SetActive(false);
        puzzleMaker.ShowPuzzle(-1);
        active = levelSelect;
        active.SetActive(true);
    }

    public void LoadLevel(int puz)
    {
        active.SetActive(false);
        puzzleMaker.ShowPuzzle(puz);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
