using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] movePoint;
    private int randomPoint;

    void Start()
    {
        waitTime = startWaitTime;
        randomPoint = Random.Range(0, movePoint.Length);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint[randomPoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoint[randomPoint].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomPoint = Random.Range(0, movePoint.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
