using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsSceneBehaviour : MonoBehaviour
{
    public Animator animator;
    public Image black;

    private void Start()
    {
        PauseMenu.CanBePaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }

    public void LoadMenu()
    {
        StartCoroutine(WaitForSceneLoad());
        PauseMenu.CanBePaused = false;
        TeleportToLvl1.StartTeleport = 0;
        TeleportToLvl2.StartTeleport = 0;
    }

    IEnumerator WaitForSceneLoad()
    {
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Menu");
    }
}
