using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipIntroTrigger : MonoBehaviour
{
    public Animator animator;
    public Image black;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PauseMenu.CanBePaused = true;
            StartCoroutine(WaitForSceneLoad());
        }
    }

    IEnumerator WaitForSceneLoad()
    {
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Valley", LoadSceneMode.Single);
    }
}
