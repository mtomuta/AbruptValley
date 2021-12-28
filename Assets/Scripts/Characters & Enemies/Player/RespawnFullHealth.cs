using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFullHealth : MonoBehaviour
{
    public PlayerController player;

    void Update()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void RespawnWithFullHealth()
    {
        player.GetComponent<Health>().baseHealth = 6;
        player.GetComponent<Health>().ActualHealth = 6;
        player.GetComponent<Health>().currentHealthBar.fillAmount = (float)player.GetComponent<Health>().ActualHealth / player.GetComponent<Health>().baseHealth;
    }
}
