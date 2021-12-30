using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static DeathMenu instance;

    public CanvasGroup canGroup;
    public PlayerController player;
    public GameObject deathMenuUI;

    void Start()
    {
        canGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.dead == true)
        {
            ShowDeathMenu();
        }
    }

    public void ShowDeathMenu()
    {
        canGroup.alpha = 1;
        canGroup.interactable = true;
        canGroup.blocksRaycasts = true;
    }

    public void HideDeathMenu()
    {
        canGroup.alpha = 0;
        canGroup.interactable = false;
        canGroup.blocksRaycasts = false;
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Valley");
        player.GetComponent<LvlExperience>().ResetAttributePoints();
        player.GetComponent<LvlExperience>().ResetXpAndLevel();
        PauseMenu.CanBePaused = true;
        TeleportToLvl1.StartTeleport = 0;
        TeleportToLvl2.StartTeleport = 0;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        player.GetComponent<LvlExperience>().ResetAttributePoints();
        player.GetComponent<LvlExperience>().ResetXpAndLevel();
        PauseMenu.CanBePaused = false;
        TeleportToLvl1.StartTeleport = 0;
        TeleportToLvl2.StartTeleport = 0;
    }
}
