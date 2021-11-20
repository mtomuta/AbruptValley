using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPersistence : MonoBehaviour
{
    private static bool propPersistence;

    void Awake()
    {
        if (!propPersistence)
        {
            propPersistence = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
