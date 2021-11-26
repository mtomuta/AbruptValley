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
        characterPanelUI.SetActive(false);
        Time.timeScale = 1f;
        CharacterPanlIsUp = false;
    }

    void Pause()
    {
        characterPanelUI.SetActive(true);
        Time.timeScale = 1f;
        CharacterPanlIsUp = true;
    }
}
