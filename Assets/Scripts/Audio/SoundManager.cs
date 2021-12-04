using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static AudioClip bringerDeath, footstep, levelUp, playerDeath, playerSwordAttack, skeletonDeath, skeletonWalk, vaseBreak;
    public static AudioSource audio;

    private void Start()
    {
        audio = GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>();

        bringerDeath = Resources.Load<AudioClip>("bringerDeath");
        footstep = Resources.Load<AudioClip>("footstep");
        levelUp = Resources.Load<AudioClip>("levelUp");
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerSwordAttack = Resources.Load<AudioClip>("playerSwordAttack");
        skeletonDeath = Resources.Load<AudioClip>("skeletonDeath");
        skeletonWalk = Resources.Load<AudioClip>("skeletonWalk");
        vaseBreak = Resources.Load<AudioClip>("vaseBreak");
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bringerDeath":
                audio.PlayOneShot(bringerDeath);
                audio.volume = 0.5f;
                break;

            case "footstep":
                audio.PlayOneShot(footstep);
                audio.volume = 0.1f;
                break;

            case "levelUp":
                audio.PlayOneShot(levelUp);
                audio.volume = 0.5f;
                break;

            case "playerSwordAttack":
                audio.PlayOneShot(playerSwordAttack);
                audio.volume = 0.25f;
                break;

            case "playerDeath":
                audio.PlayOneShot(playerDeath);
                audio.volume = 0.5f;
                break;

            case "skeletonDeath":
                audio.PlayOneShot(skeletonDeath);
                audio.volume = 0.5f;
                break;

            case "skeletonWalk":
                audio.PlayOneShot(skeletonWalk);
                audio.volume = 0.5f;
                break;

            case "vaseBreak":
                audio.PlayOneShot(vaseBreak);
                audio.volume = 0.3f;
                break;
        }
    }
}
