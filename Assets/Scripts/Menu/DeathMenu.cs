using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;

    public void NewGame()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Valley");
        PauseMenu.CanBePaused = true;
        TeleportToLvl1.StartTeleport = 0;
        TeleportToLvl2.StartTeleport = 0;
    }

    public void LoadMenu()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        PauseMenu.CanBePaused = false;
        TeleportToLvl1.StartTeleport = 0;
        TeleportToLvl2.StartTeleport = 0;
    }
}
