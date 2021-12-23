using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadByTag : MonoBehaviour
{
    private void Awake()
    {
        //GameObject[] gameMusic = GameObject.FindGameObjectsWithTag("GameMusic");
        //GameObject[] musicController = GameObject.FindGameObjectsWithTag("MusicController");
        //GameObject[] soundManager = GameObject.FindGameObjectsWithTag("SoundManager");
        //GameObject[] soundController = GameObject.FindGameObjectsWithTag("SoundController");

        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        GameObject[] sound = GameObject.FindGameObjectsWithTag("Sound");

        GameObject[] canvasMainMenu = GameObject.FindGameObjectsWithTag("CanvasMainMenu");
        GameObject[] canvasMenus = GameObject.FindGameObjectsWithTag("CanvasMenus");

        GameObject[] canvasCharacterPanel = GameObject.FindGameObjectsWithTag("CanvasCharacterPanel");
        GameObject[] canvasHealthSystem = GameObject.FindGameObjectsWithTag("CanvasHealthSystem");
        GameObject[] deathMenu = GameObject.FindGameObjectsWithTag("DeathMenu");

        if (music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else if (sound.Length > 1)
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
        else if (deathMenu.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
