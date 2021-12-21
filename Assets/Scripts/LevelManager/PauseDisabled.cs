using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDisabled : MonoBehaviour
{
    void Start()
    {
        PauseMenu.CanBePaused = false;
    }
}
