using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static AudioClip bringerDeath, closeChest, footstep, levelUp, openChest, playerDeath, playerHeal, playerSwordAttack, skeletonDeath, skeletonWalk, vaseBreak;
    public static AudioSource audio;

    private void Start()
    {
        audio = GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>();

        bringerDeath = Resources.Load<AudioClip>("bringerDeath");
        closeChest = Resources.Load<AudioClip>("closeChest");
        footstep = Resources.Load<AudioClip>("footstep");
        levelUp = Resources.Load<AudioClip>("levelUp");
        openChest = Resources.Load<AudioClip>("openChest");
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerHeal = Resources.Load<AudioClip>("playerHeal");
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

            case "closeChest":
                audio.PlayOneShot(closeChest);
                audio.volume = 0.3f;
                break;

            case "footstep":
                audio.PlayOneShot(footstep);
                audio.volume = 0.1f;
                break;

            case "levelUp":
                audio.PlayOneShot(levelUp);
                audio.volume = 0.5f;
                break;

            case "openChest":
                audio.PlayOneShot(openChest);
                audio.volume = 0.3f;
                break;

            case "playerDeath":
                audio.PlayOneShot(playerDeath);
                audio.volume = 0.5f;
                break;

            case "playerHeal":
                audio.PlayOneShot(playerHeal);
                audio.volume = 0.5f;
                break;

            case "playerSwordAttack":
                audio.PlayOneShot(playerSwordAttack);
                audio.volume = 0.25f;
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
