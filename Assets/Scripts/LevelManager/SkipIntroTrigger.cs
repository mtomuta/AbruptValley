using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipIntroTrigger : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Valley", LoadSceneMode.Single);
            PauseMenu.CanBePaused = true;
        }
    }
}
