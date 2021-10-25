using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float offSet = 1f;
    public Vector2 hitBox = new Vector2(1,1);
    private Vector2 attackVectorOffSet;
    private Vector2 pointA, pointB; 

    private void Update()
    {
        Debug.DrawLine(transform.position, (Vector2)transform.position + attackVectorOffSet, Color.yellow);
        Debug.DrawLine(pointA, pointB, Color.red);
    }

    public void Attack(Vector2 attackDirection, int damage)
    {
        attackVectorOffSet = attackDirection.normalized * offSet;
        pointA = (Vector2)transform.position + attackVectorOffSet - hitBox * 0.5f;
        pointB = pointA + hitBox;
    }
}
