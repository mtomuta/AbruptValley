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
            StartCoroutine(WaitAndUnfreeze());
        }
    }

    IEnumerator WaitForSceneLoad()
    {
        animator.SetTrigger("Fade");
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Dungeon");
        FreezePosition();
    }

    IEnumerator WaitAndUnfreeze()
    {
        yield return WaitForSceneLoad();
        UnfreezePosition();
    }

    void FreezePosition()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    void UnfreezePosition()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
