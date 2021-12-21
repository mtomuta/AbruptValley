using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip menuMusic;
    [SerializeField]
    private AudioClip introMusic;
    [SerializeField]
    private AudioClip valleyMusic;
    [SerializeField]
    private AudioClip dungeonMusic;
    [SerializeField]
    private AudioClip endingCreditsMusic;

    private AudioSource audio;
    static private MusicManager instance;

    private string lastScene;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        lastScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != lastScene)
        {
            lastScene = currentScene;
            SwitchMusic();
        }

        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!audio.isPlaying)
        {
            SwitchMusic();
        }
    }

    public void SwitchMusic()
    {
        if (lastScene == "Menu")
        {
            audio.Stop();
            audio.clip = menuMusic;
            audio.Play();
        }
        else if (lastScene == "Intro")
        {
            audio.Stop();
            audio.clip = introMusic;
            audio.Play();
        }
        else if ( lastScene == "Valley")
        {
            audio.Stop();
            audio.clip = valleyMusic;
            audio.Play();
        }
        else if (lastScene == "Dungeon")
        {
            audio.Stop();
            audio.clip = dungeonMusic;
            audio.Play();
        }
        else if (lastScene == "EndingCredits")
        {
            audio.Stop();
            audio.clip = endingCreditsMusic;
            audio.Play();
        }
    }
}
