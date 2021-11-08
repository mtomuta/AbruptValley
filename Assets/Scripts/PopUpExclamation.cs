using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpExclamation : MonoBehaviour
{
    public bool playerInRange;
    public string otherTag;
    [SerializeField] GameObject exclamation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            exclamation.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
            exclamation.SetActive(false);
        }
    }
}
