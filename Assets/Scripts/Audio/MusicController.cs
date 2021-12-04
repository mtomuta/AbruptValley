using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private float musicVolume = 1f;

    public AudioSource audio;
    public Slider musicSlider;

    private void Start()
    {
        audio = GameObject.FindWithTag("GameMusic").GetComponent<AudioSource>();
        musicSlider = GameObject.FindWithTag("MusicSlider").GetComponent<Slider>();

        musicVolume = PlayerPrefs.GetFloat("music");
        audio.volume = musicVolume;
        musicSlider.value = musicVolume;
    }

    private void Update()
    {
        audio.volume = musicVolume;
        PlayerPrefs.SetFloat("music", musicVolume);
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }

    public void ResetMusic()
    {
        PlayerPrefs.DeleteKey("music");
        audio.volume = 1;
        musicSlider.value = 1;
    }
}
