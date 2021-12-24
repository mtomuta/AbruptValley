using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMainMenuController : MonoBehaviour
{
    public CanvasGroup canGroup;

    void Start()
    {
        canGroup = GetComponent<CanvasGroup>();
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            ActiveMainMenuAndChests();
        }
        else if (SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "Valley" || SceneManager.GetActiveScene().name == "Dungeon" || SceneManager.GetActiveScene().name == "EndingCredits")
        {
            HideMainMenuAndChests();
        }
    }

    public void ActiveMainMenuAndChests()
    {
        canGroup.alpha = 1;
        canGroup.interactable = true;
        canGroup.blocksRaycasts = true;
    }

    public void HideMainMenuAndChests()
    {
        canGroup.alpha = 0;
        canGroup.interactable = false;
        canGroup.blocksRaycasts = false;
    }
}
