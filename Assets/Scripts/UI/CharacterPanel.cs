using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharacterPanel : MonoBehaviour
{
    public static CharacterPanel instance;

    public static bool PanelIsDisplayed = true;
    public static bool CanBeDisplayed = true;
    
    public GameObject characterPanelUI;
    public UnityEvent onKeyDown;  

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Valley" || SceneManager.GetActiveScene().name == "Dungeon")
        {
            CanBeDisplayed = true;
        }
        else if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "EndingCredits")
        {
            CanBeDisplayed = false;
        }

        if (CanBeDisplayed)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                onKeyDown?.Invoke();
                if (PanelIsDisplayed && SceneManager.GetActiveScene().name == "Valley" || PanelIsDisplayed && SceneManager.GetActiveScene().name == "Dungeon")
                {
                    HidePanel();
                }
                else
                {
                    ShowPanel();
                }
            }
        }
    }

    public void HidePanel()
    {
        characterPanelUI.SetActive(false);
        PanelIsDisplayed = false;
    }

    public void ShowPanel()
    {
        characterPanelUI.SetActive(true);
        PanelIsDisplayed = true;
    }
}
