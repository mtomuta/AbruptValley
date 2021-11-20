using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeleportToLvl2 : MonoBehaviour
{
    public static int StartTeleport = 0;

    public Animator animator;
    public Image black;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && TeleportToLvl2.StartTeleport == 1)
        {
            TeleportToLvl2.StartTeleport = 0;
            StartCoroutine(WaitForSceneLoad());
        }
    }

    IEnumerator WaitForSceneLoad()
    {
        //yield return new WaitForSeconds(1);
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Dungeon");
    }
}
