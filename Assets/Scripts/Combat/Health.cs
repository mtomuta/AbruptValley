using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int baseHealth;
    private int actualHealth;
    public UnityEvent onDeath;

    public int ActualHealth
    {
        get
        {
            return actualHealth;
        }
        set
        {
            if (value > 0)
            {
                actualHealth = value;
            }
            else
            {
                actualHealth = 0;
                Destroy(gameObject,0.5f);
            }
        }
    }

    void Start()
    {
        ActualHealth = baseHealth;
    }
}
