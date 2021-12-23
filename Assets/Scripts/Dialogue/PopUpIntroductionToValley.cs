using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpIntroductionToValley : MonoBehaviour
{
    public static int PopUpEnabled = 1;
    public static int PopUpTextEnabled = 1;
    [SerializeField] GameObject PopUpIntro;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && PopUpEnabled == 1 && PopUpTextEnabled == 1)
        {
            PopUpIntro.SetActive(true);
            CinemachineShake.Instance.ShakeCamera(5f, 2f);
            SoundManager.PlaySound("earthquake");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PopUpEnabled = 0;
        PopUpTextEnabled = 0;
        PopUpIntro.SetActive(false);
    }
}
