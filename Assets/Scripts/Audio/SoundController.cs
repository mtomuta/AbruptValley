using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private float soundVolume = 1f;

    public AudioSource audio;
    public Slider soundSlider;

    private void Start()
    {
        audio = GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>();
        soundSlider = GameObject.FindWithTag("SoundSlider").GetComponent<Slider>();

        soundVolume = PlayerPrefs.GetFloat("sound");
        audio.volume = soundVolume;
        soundSlider.value = soundVolume;
    }

    private void Update()
    {
        audio.volume = soundVolume;
        PlayerPrefs.SetFloat("sound", soundVolume);
    }

    public void UpdateVolume(float volume)
    {
        soundVolume = volume;
    }

    public void ResetMusic()
    {
        PlayerPrefs.DeleteKey("sound");
        audio.volume = 1;
        soundSlider.value = 1;
    }
}