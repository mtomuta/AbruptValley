using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    private Health myHealth;
    //private Rigidbody2D myRigidbody;

    private void Start()
    {
        myHealth = GetComponent<Health>();
        //myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void ReceiveAttack()
    {
        myHealth.ActualHealth -= 1;
    }

    //public void ReceiveAttack(int damage, Vector2 attackDirection)
    //{
    //myHealth.modifyActualHealth(damage);
    //myRigidbody.AddForce(attackDirection);
    //}
}
