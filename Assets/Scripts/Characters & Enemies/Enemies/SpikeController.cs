using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public Animator animator;
    public Attributes attributes;
    private Attacker attacker;
    protected InputEnemy input;

    public float startWaitTime;
    public float waitTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        input = GetComponent<InputEnemy>();
    }

    void Update()
    {
        if (waitTime <= 0)
        {
            waitTime = startWaitTime;
            animator.SetBool("attack", true);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    public void SpikeDamage()
    {
        attacker.Attack(input.directionTowardsPlayer, attributes.attack);
    }

    public void SetAttackFalse()
    {
        animator.SetBool("attack", false);
    }
}
