using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCharacterPanelController : MonoBehaviour
{
    private static bool canvasExists;

    void Awake()
    {
        if (!canvasExists)
        {
            canvasExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
