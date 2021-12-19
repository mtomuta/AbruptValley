using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMainMenuController : MonoBehaviour
{
    private CanvasGroup canGroup;

    private static bool canvasExists;

    void Awake()
    {
        if (!canvasExists)
        {
            canvasExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        else
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
