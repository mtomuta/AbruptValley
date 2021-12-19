using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadByTag : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] gameMusic = GameObject.FindGameObjectsWithTag("GameMusic");
        GameObject[] musicController = GameObject.FindGameObjectsWithTag("MusicController");
        GameObject[] soundManager = GameObject.FindGameObjectsWithTag("SoundManager");
        GameObject[] soundController = GameObject.FindGameObjectsWithTag("SoundController");

        GameObject[] canvasMainMenu = GameObject.FindGameObjectsWithTag("CanvasMainMenu");
        GameObject[] canvasMenus = GameObject.FindGameObjectsWithTag("CanvasMenus");

        GameObject[] canvasCharacterPanel = GameObject.FindGameObjectsWithTag("CanvasCharacterPanel");
        GameObject[] canvasHealthSystem = GameObject.FindGameObjectsWithTag("CanvasHealthSystem");

        if (gameMusic.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (musicController.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (soundManager.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (soundController.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (canvasMainMenu.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (canvasMenus.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (canvasCharacterPanel.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (canvasHealthSystem.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
