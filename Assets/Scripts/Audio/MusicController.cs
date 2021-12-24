using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource audio;
    public Slider musicSlider;

    void Start()
    {
        //audio = GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>();
        //musicSlider = GameObject.FindWithTag("MusicSlider").GetComponent<Slider>();

        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetFloat("music", 1);
            LoadMusicValue();
        }
        else
        {
            LoadMusicValue();
        }
    }

    public void UpdateVolume()
    {
        audio.volume = musicSlider.value;
        SaveMusicValue();
    }

    public void LoadMusicValue()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music");
    }

    public void SaveMusicValue()
    {
        PlayerPrefs.SetFloat("music", musicSlider.value);
    }

    //public void ResetMusic()
    //{
    //    PlayerPrefs.DeleteKey("music");
    //    audio.volume = 1;
    //    musicSlider.value = 1;
    //}
}
