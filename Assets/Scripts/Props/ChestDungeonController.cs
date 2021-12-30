using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDungeonController : MonoBehaviour
{
    public bool isOpened;
    public Animator animator;

    [SerializeField] GameObject popUp;

    public void OpenChest()
    {
        if (!isOpened)
        {
            isOpened = true;
            animator.SetBool("isOpened", isOpened);
            popUp.SetActive(true);
            SoundManager.PlaySound("openChest");
        }
        else
        {
            isOpened = false;
            animator.SetBool("isOpened", isOpened);
            popUp.SetActive(false);
            SoundManager.PlaySound("closeChest");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            popUp.SetActive(false);
        }
    }
}
