using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public bool playerInRange;
    public string otherTag;
    [SerializeField] GameObject popUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            popUp.SetActive(true);
            SoundManager.PlaySound("interaction");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
            popUp.SetActive(false);
            
        }
    }
}
