using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeleportToLvl1 : MonoBehaviour
{
    //public GameObject Player, RespawnPoint;
    //public GameObject GameManager;
    public static int StartTeleport = 0;

    public Animator animator;
    public Image black;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && TeleportToLvl1.StartTeleport == 1)
        {
            TeleportToLvl1.StartTeleport = 0;
            StartCoroutine(WaitForSceneLoad());
        }
    }

    IEnumerator WaitForSceneLoad()
    {
        //yield return new WaitForSeconds(1);
        animator.SetTrigger("Fade");
        yield return new WaitUntil(()=>black.color.a == 1);
        SceneManager.LoadScene("Valley");

        //GameManager.Player.transform.position = GameManager.playerSpawnPoint.position;
        //Player.transform.position = new Vector2(-11,28);
        //gm.player.transform.position = gm.playerSpawnPoint.position;
        //gm.playerSpawnPoint = FindObjectOfType<RespawnPoint>().transform;
    }
}
