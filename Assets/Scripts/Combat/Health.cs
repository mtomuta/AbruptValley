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
            if (value > 0 && value<=baseHealth)
            {
                actualHealth = value;
            }
            else if (value > baseHealth)
            {
                actualHealth = baseHealth;
            }
            else
            {
                actualHealth = 0;
                if (onDeath != null)
                {
                    onDeath.Invoke();
                }
            }
        }
    }

    void Start()
    {
        ActualHealth = baseHealth;
    }

    //public void modifyActualHealth(int amount)
    //{
    //    ActualHealth += amount;
    //}

    private void DestroyGameObject()
    {
        Destroy(gameObject);
        //Destroy(gameObject, 0.5f)
    }
}
