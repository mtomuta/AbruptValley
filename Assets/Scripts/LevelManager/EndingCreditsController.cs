using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndingCreditsController : MonoBehaviour
{
    public bool inRange;

    public CharacterPanel chPanel;

    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Update()
    {
        chPanel = FindObjectOfType<CharacterPanel>();
        
        if (inRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    public void CloseChPanel()
    {
        chPanel.characterPanelUI.SetActive(false);
    }

    public void GameCreditsScreen()
    {
        SceneManager.LoadScene("EndingCredits");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
