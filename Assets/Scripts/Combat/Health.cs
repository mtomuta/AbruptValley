using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int baseHealth;
    public int actualHealth;

    public Image currentHealthBar;
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
                gameObject.layer = 8;
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

    public void UpdateActualHealth(int damage)
    {
        ActualHealth -= damage;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (currentHealthBar)
        {
            //Vector3 scale = new Vector3((float)ActualHealth / baseHealth, 1, 1);
            //currentHealthBar.localScale = scale;
            currentHealthBar.fillAmount = (float)ActualHealth / baseHealth;
        }
    }

    public void RespawnBaseHealth()
    {
        ActualHealth = baseHealth;
        UpdateHealthBar();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
        //Destroy(gameObject, 0.5f)
    }
}
