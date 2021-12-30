using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool CanBePaused = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public PlayerController player;
    public CharacterPanel chPanel;

    void Update()
    {
        player = FindObjectOfType<PlayerController>();
        chPanel = FindObjectOfType<CharacterPanel>();

        if (SceneManager.GetActiveScene().name == "Valley" || SceneManager.GetActiveScene().name == "Dungeon")
        {
            CanBePaused = true;
        }
        else if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "EndingCredits")
        {
            CanBePaused = false;
        }

        if (CanBePaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);

        chPanel.characterPanelUI.SetActive(false);

        Time.timeScale = 1f;
    }

    public virtual void Pause()
    {
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);

        chPanel.characterPanelUI.SetActive(false);

        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        chPanel.characterPanelUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        player.GetComponent<LvlExperience>().ResetAttributePoints();
        player.GetComponent<LvlExperience>().ResetXpAndLevel();
        CanBePaused = false;
        TeleportToLvl1.StartTeleport = 0;
        TeleportToLvl2.StartTeleport = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
