using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportActivationToLvl2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TeleportToLvl2.StartTeleport = 1;
        }
    }
}
