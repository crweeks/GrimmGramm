using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Music", 1);
        PlayerPrefs.SetInt("Mute", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMusic()
    {
        int mute = PlayerPrefs.GetInt("Music");
        if (mute == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
            GameObject.Find("Music").transform.Find("MusicControler").GetComponent<AudioSource>().mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            GameObject.Find("Music").transform.Find("MusicControler").GetComponent<AudioSource>().mute = false;
        }
    }

    public void ToggleSound()
    {
        int mute = PlayerPrefs.GetInt("Mute");
        if (mute == 1) PlayerPrefs.SetInt("Mute", 0);
        else PlayerPrefs.SetInt("Mute", 1);
    }
}
