using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource AudioSource;
    private float musicVolume = 1f;

    private static bool volumeControllerExists;

    void Start()
    {   
        AudioSource.Play();

        if (!volumeControllerExists)
        {
            volumeControllerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
