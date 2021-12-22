using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterPanel : MonoBehaviour
{
    public static bool CharacterPanlIsUp = false;

    public GameObject characterPanelUI;
    public UnityEvent onKeyDown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            onKeyDown?.Invoke();
            if (CharacterPanlIsUp)
            {
                ResumeGame();
            }
            else
            {
                ShowPanel();
            }
        }
    }

    public void ResumeGame()
    {
        characterPanelUI.SetActive(false);
        Time.timeScale = 1f;
        CharacterPanlIsUp = false;
    }

    void ShowPanel()
    {
        characterPanelUI.SetActive(true);
        Time.timeScale = 1f;
        CharacterPanlIsUp = true;
    }
}
