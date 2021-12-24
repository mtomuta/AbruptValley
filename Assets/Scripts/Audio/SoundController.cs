using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioSource audio;
    public Slider soundSlider;

    private void Start()
    {
        //audio = GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>();
        //soundSlider = GameObject.FindWithTag("SoundSlider").GetComponent<Slider>();

        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetFloat("sound", 1);
            LoadSoundValue();
        }
        else
        {
            LoadSoundValue();
        }
    }

    public void UpdateVolume()
    {
        audio.volume = soundSlider.value;
        SaveSoundValue();
    }

    public void LoadSoundValue()
    {
        soundSlider.value = PlayerPrefs.GetFloat("sound");
    }

    public void SaveSoundValue()
    {
        PlayerPrefs.SetFloat("sound", soundSlider.value);
    }

    //public void ResetMusic()
    //{
    //    PlayerPrefs.DeleteKey("sound");
    //    audio.volume = 1;
    //    soundSlider.value = 1;
    //}
}