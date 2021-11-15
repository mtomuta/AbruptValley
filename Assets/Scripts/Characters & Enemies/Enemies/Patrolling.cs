using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public float startWaitTime;
    private float waitTime;
    private float currentXPosition;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Animator animator;
    public Attributes attributes;
    private SpriteRenderer spriteRenderer;
    public Transform moveToPoint;

    private int walkingHashCode;

    void Start()
    {
        currentXPosition = transform.position.x;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkingHashCode = Animator.StringToHash("Walking");
    }

    void Update()
    {
        Patrol();
        FlipSprite();

        if (Vector2.Distance(transform.position, moveToPoint.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                moveToPoint.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public virtual void Patrol()
    {
        animator.SetBool(walkingHashCode, true);
        transform.position = Vector2.MoveTowards(transform.position, moveToPoint.position, attributes.speed * Time.deltaTime);
    }

    void FlipSprite()
    {
        if (transform.position.x > currentXPosition)
        {
            currentXPosition = transform.position.x;
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < currentXPosition)
        {
            currentXPosition = transform.position.x;
            spriteRenderer.flipX = true;
        }
    }
}
