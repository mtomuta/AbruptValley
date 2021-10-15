using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float offSet = 1f;
    public Vector2 hitBox = new Vector2(1,1);

    public void Attack(Vector2 attackDirection, int damage)
    {
        Vector2 attackVector = attackDirection.normalized * offSet;
        Vector2 pointA = (Vector2)transform.position + attackVector - hitBox * 0.5f;
        Vector2 pointB = pointA + hitBox;
    }
}
