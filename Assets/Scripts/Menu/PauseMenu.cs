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
    //public GameObject characterPanelUI;

    void Awake()
    {
        //characterPanelUI = GameObject.FindWithTag("CharacterPanel");
    }

    void Start()
    {
        //characterPanelUI = GameObject.FindWithTag("CharacterPanel");
    }

    void Update()
    {
        Behaviour();
    }

    public virtual void Behaviour()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (!CanBePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        GameIsPaused = false;

        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        //characterPanelUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public virtual void Pause()
    {
        GameIsPaused = true;

        //characterPanelUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        CanBePaused = false;
        TeleportToLvl1.StartTeleport = 0;
        TeleportToLvl2.StartTeleport = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
