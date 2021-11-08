using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    private Health myHealth;

    private void Start()
    {
        myHealth = GetComponent<Health>();
    }

    public void ReceiveAttack()
    {
        myHealth.ActualHealth -= 1;
    }
}
