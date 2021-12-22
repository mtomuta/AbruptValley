using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadingBetweenScenes : MonoBehaviour
{
    public Animator animator;
    public Image black;

    void Start()
    {
        StartCoroutine(WaitForSceneLoad());
    }

    IEnumerator WaitForSceneLoad()
    {
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
