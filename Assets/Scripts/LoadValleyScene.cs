using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadValleyScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Valley", LoadSceneMode.Single);
    }
}
