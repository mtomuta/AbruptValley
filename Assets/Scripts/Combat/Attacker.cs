using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float offSet = 1f;

    public Vector2 hitBox = new Vector2(1,1);
    private Vector2 attackVectorOffSet;
    private Vector2 pointA, pointB;

    public LayerMask attackLayer;
    private Collider2D[] colliderAttack = new Collider2D[10];
    private ContactFilter2D attackFilter;

    private void Start()
    {
        attackFilter.layerMask = attackLayer;
        attackFilter.useLayerMask = true;
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, (Vector2)transform.position + attackVectorOffSet, Color.yellow);
        Debug.DrawLine(pointA, pointB, Color.red);
    }

    public void Attack(Vector2 attackDirection, int damage)
    {
        HitBoxInteraction(attackDirection);
        GameObject attackedObject;
        int attackedElements = Physics2D.OverlapArea(pointA, pointB, attackFilter, colliderAttack);

        for (int i=0; i < attackedElements; i++)
        {
            attackedObject = colliderAttack[i].gameObject;
            if (attackedObject.GetComponent<Attackable>())
            {
                attackedObject.GetComponent<Attackable>().ReceiveAttack(attackDirection, damage);
            }
        }
    }

    private void HitBoxInteraction(Vector2 attackDirection)
    {
        Vector2 scale = transform.lossyScale;
        Vector2 scaledHitBox = Vector2.Scale(hitBox, scale);
        attackVectorOffSet = Vector2.Scale(attackDirection.normalized * offSet, scale);
        pointA = (Vector2)transform.position + attackVectorOffSet - scaledHitBox * 0.5f;
        pointB = pointA + scaledHitBox;
    }
}
