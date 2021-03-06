using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(InputEnemy))]
public class EnemyAI : Enemy
{
    protected bool dead;
    private bool aggro;
    private bool attacking;
    private bool inCombat;

    private int attackHashCode;
    private int walkingHashCode;
    protected int deathHashCode;

    protected Patrolling patrolling;
    protected PatrollingReverseSprite patrollingReverseSprite;
    protected InputEnemy input;
    private Attacker attacker;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    private Vector2 attackDirection;
    private Rigidbody2D myRigidbody2D;
    //public Attributes attributes;

    [SerializeField] private float aggroDistance;
    [SerializeField] private float attackDistance;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        input = GetComponent<InputEnemy>();
        patrolling = GetComponent<Patrolling>();
        patrollingReverseSprite = GetComponent<PatrollingReverseSprite>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackHashCode = Animator.StringToHash("Attack");
        deathHashCode = Animator.StringToHash("Death");
        walkingHashCode = Animator.StringToHash("Walking");
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Behaviour();
    }

    protected void Behaviour()
    {
        if (!dead)
        {
            if (!attacking && input.playerDistance < attackDistance)
            {
                DoAttack();
            }
            else if (!attacking && (inCombat || input.playerDistance < aggroDistance))
            {
                MoveToPlayer();
            }
            else if (input.playerDistance > aggroDistance)
            {
                AggroOff();
                if (gameObject.CompareTag("Skeleton"))
                {
                    patrolling.Patrol();
                }
                else if (gameObject.CompareTag("Bringer"))
                {
                    patrollingReverseSprite.Patrol();
                }
                //myRigidbody2D.velocity = Vector2.zero;
                //myRigidbody2D.Sleep();
                //Debug.Log("No estoy a distancia");
                //}
            }
        }
    }

    private void MoveToPlayer()
    {
        animator.SetBool(walkingHashCode, true);
        FlipSprite();
        transform.position += (Vector3)input.directionTowardsPlayer * attributes.speed * Time.deltaTime;
    }

    private void AggroOff()
    {
        attacking = false;
        inCombat = false;
    }

    private void DoAttack()
    {
        int attackProbability = Random.Range(0, 100);
        animator.SetBool(walkingHashCode, false);

        if (attackProbability > 95)
        {
            attackDirection = input.directionTowardsPlayer;
            attacking = true;
            inCombat = true;
            animator.SetTrigger(attackHashCode);
        }
    }

    public virtual void EnemyAttack()
    {
        attacker.Attack(input.directionTowardsPlayer, attributes.attack);
    }

    protected virtual void FlipSprite()
    {
        if (input.horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void SetAttackFalse()
    {
        attacking = false;
    }

    protected virtual void Dead()
    {
        dead = true;
        animator.SetBool(deathHashCode, true);
    }
}
