using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWayToLvl1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TeleportToLvl1.StartTeleport = 1;
        }
    }
}
