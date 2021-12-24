using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDungeonController : MonoBehaviour
{
    public bool isOpened;
    public Animator animator;

    public void OpenChest()
    {
        if (!isOpened)
        {
            isOpened = true;
            animator.SetBool("isOpened", isOpened);
            SoundManager.PlaySound("openChest");
        }
        else
        {
            isOpened = false;
            animator.SetBool("isOpened", isOpened);
            SoundManager.PlaySound("closeChest");
        }
    }
}
