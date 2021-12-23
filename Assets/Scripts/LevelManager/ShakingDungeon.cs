using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakingDungeon : MonoBehaviour
{
    public static int ShakeEnabled = 1;
    public static int ShakeTextEnabled = 1;
    [SerializeField] GameObject shakePopUp;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && ShakeEnabled == 1 && ShakeTextEnabled == 1)
        {
            shakePopUp.SetActive(true);
            CinemachineShake.Instance.ShakeCamera(5f, 2f);
            SoundManager.PlaySound("earthquake");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ShakeEnabled = 0;
        ShakeTextEnabled = 0;
        shakePopUp.SetActive(false);
    }
}
