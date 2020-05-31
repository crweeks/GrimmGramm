using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Mute", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMute()
    {
        int mute = PlayerPrefs.GetInt("Mute");
        if (mute == 1)
        {
            PlayerPrefs.SetInt("Mute", 0);
            GameObject.Find("Music").transform.Find("MusicControler").GetComponent<AudioSource>().mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 1);
            GameObject.Find("Music").transform.Find("MusicControler").GetComponent<AudioSource>().mute = false;
        }
    }
}
