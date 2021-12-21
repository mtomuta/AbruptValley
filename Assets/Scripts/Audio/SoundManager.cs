using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static AudioClip bringerDeath, closeChest, footstep, interaction, levelUp, openChest, playerDeath, playerHeal, playerSwordAttack, select, skeletonDeath, skeletonWalk, teleport, vaseBreak;
    public static AudioSource audio;

    private void Start()
    {
        audio = GameObject.FindWithTag("SoundManager").GetComponent<AudioSource>();

        bringerDeath = Resources.Load<AudioClip>("bringerDeath");
        closeChest = Resources.Load<AudioClip>("closeChest");
        footstep = Resources.Load<AudioClip>("footstep");
        interaction = Resources.Load<AudioClip>("interaction");
        levelUp = Resources.Load<AudioClip>("levelUp");
        openChest = Resources.Load<AudioClip>("openChest");
        playerDeath = Resources.Load<AudioClip>("playerDeath");
        playerHeal = Resources.Load<AudioClip>("playerHeal");
        playerSwordAttack = Resources.Load<AudioClip>("playerSwordAttack");
        select = Resources.Load<AudioClip>("select");
        skeletonDeath = Resources.Load<AudioClip>("skeletonDeath");
        skeletonWalk = Resources.Load<AudioClip>("skeletonWalk");
        teleport = Resources.Load<AudioClip>("teleport");
        vaseBreak = Resources.Load<AudioClip>("vaseBreak");
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bringerDeath":
                audio.PlayOneShot(bringerDeath, 0.5f);
                break;

            case "closeChest":
                audio.PlayOneShot(closeChest, 0.3f);
                break;

            case "footstep":
                audio.PlayOneShot(footstep, 0.1f);
                break;

            case "interaction":
                audio.PlayOneShot(interaction, 0.6f);
                break;

            case "levelUp":
                audio.PlayOneShot(levelUp, 0.5f);
                break;

            case "openChest":
                audio.PlayOneShot(openChest, 0.3f);
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

            case "skeletonWalk":
                audio.PlayOneShot(skeletonWalk, 0.5f);
                break;

            case "teleport":
                audio.PlayOneShot(teleport, 0.6f);
                break;

            case "vaseBreak":
                audio.PlayOneShot(vaseBreak, 0.3f);
                break;
        }
    }

    public void PlaySelectSound()
    {
        SoundManager.PlaySound("select");
    }
}
