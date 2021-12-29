using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static AudioClip bringerDeath, closeChest, devilEyeDeath, earthquake, footstep, interaction, levelUp, mushroomDeath, openChest, playerDeath, playerHeal, playerSwordAttack, select, skeletonDeath, teleport, throwProjectile, vaseBreak, wizardDeath;
    public static AudioSource audio;

    private void Start()
    {
        audio = GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>();

        bringerDeath = Resources.Load<AudioClip>("bringerDeath");
        closeChest = Resources.Load<AudioClip>("closeChest");
        devilEyeDeath = Resources.Load<AudioClip>("devilEyeDeath");
        earthquake = Resources.Load<AudioClip>("earthquake");
        footstep = Resources.Load<AudioClip>("footstep");
        interaction = Resources.Load<AudioClip>("interaction");
        levelUp = Resources.Load<AudioClip>("levelUp");
        mushroomDeath = Resources.Load<AudioClip>("mushroomDeath");
        openChest = Resources.Load<AudioClip>("openChest");
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerHeal = Resources.Load<AudioClip>("playerHeal");
        playerSwordAttack = Resources.Load<AudioClip>("playerSwordAttack");
        select = Resources.Load<AudioClip>("select");
        skeletonDeath = Resources.Load<AudioClip>("skeletonDeath");
        teleport = Resources.Load<AudioClip>("teleport");
        throwProjectile = Resources.Load<AudioClip>("throwProjectile");
        vaseBreak = Resources.Load<AudioClip>("vaseBreak");
        wizardDeath = Resources.Load<AudioClip>("wizardDeath");
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bringerDeath":
                audio.PlayOneShot(bringerDeath, 0.5f);
                break;

            case "closeChest":
                audio.PlayOneShot(closeChest, 0.25f);
                break;

            case "devilEyeDeath":
                audio.PlayOneShot(devilEyeDeath, 0.5f);
                break;

            case "earthquake":
                audio.PlayOneShot(earthquake);
                break;

            case "footstep":
                audio.PlayOneShot(footstep, 0.05f);
                break;

            case "interaction":
                audio.PlayOneShot(interaction, 0.6f);
                break;

            case "levelUp":
                audio.PlayOneShot(levelUp, 0.25f);
                break;

            case "mushroomDeath":
                audio.PlayOneShot(mushroomDeath, 0.5f);
                break;

            case "openChest":
                audio.PlayOneShot(openChest, 0.25f);
                break;

            case "playerDeath":
                audio.PlayOneShot(playerDeath, 0.5f);
                break;

            case "playerHeal":
                audio.PlayOneShot(playerHeal, 0.5f);
                break;

            case "playerSwordAttack":
                audio.PlayOneShot(playerSwordAttack, 0.25f);
                break;

            case "select":
                audio.PlayOneShot(select);
                break;

            case "skeletonDeath":
                audio.PlayOneShot(skeletonDeath, 0.5f);
                break;

            case "teleport":
                audio.PlayOneShot(teleport, 0.5f);
                break;

            case "throwProjectile":
                audio.PlayOneShot(throwProjectile, 0.5f);
                break;

            case "vaseBreak":
                audio.PlayOneShot(vaseBreak, 0.15f);
                break;

            case "wizardDeath":
                audio.PlayOneShot(wizardDeath, 0.5f);
                break;
        }
    }

    public void PlaySelectSound()
    {
        SoundManager.PlaySound("select");
    }
}
