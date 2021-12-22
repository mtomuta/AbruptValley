using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportActivationToLvl1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TeleportToLvl1.StartTeleport = 1;
            ShakingDungeon.ShakeEnabled = 1;
            ShakingDungeon.ShakeTextEnabled = 1;
        }
    }
}
