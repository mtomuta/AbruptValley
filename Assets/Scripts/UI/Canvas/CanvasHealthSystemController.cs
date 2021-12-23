using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasHealthSystemController : MonoBehaviour
{
    public CanvasGroup canGroup;

    void Start()
    {
        canGroup = GetComponent<CanvasGroup>();
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Valley" || SceneManager.GetActiveScene().name == "Dungeon")
        {
            ActivateBars();
        }
        else if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Intro" || SceneManager.GetActiveScene().name == "EndingCredits")
        {
            HideBars();
        }
    }

    public void ActivateBars()
    {
        canGroup.alpha = 1;
    }

    public void HideBars()
    {
        canGroup.alpha = 0;
    }
}
