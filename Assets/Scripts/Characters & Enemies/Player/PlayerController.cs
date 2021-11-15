using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    
    private Animator animator;
    private InputPlayer inputPlayer;
    private Rigidbody2D myRigidbody2D;
    private Transform transformed;
    private Attacker attacker;
    public Attributes playerAttributes;
    public LayerMask interactionLayer;

    int runningHashCode;
    int attackingHashCode;

    private static bool playerExists;

    void Start()
    {
        inputPlayer = GetComponent<InputPlayer>();
        transformed = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        runningHashCode = Animator.StringToHash("Running");
        attackingHashCode = Animator.StringToHash("Attacking");

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        horizontal = inputPlayer.horizontalAxis;
        vertical = inputPlayer.verticalAxis;

        if (horizontal != 0 || vertical != 0)
        {
            SetXYAnimator();
            animator.SetBool(runningHashCode, true);
        }
        else
        {
            animator.SetBool(runningHashCode, false);
        }
        
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetBool(attackingHashCode, true);
        }

        //if (player.isAbove == false)
        //{
        //    AddSortingOrder = bridge.sortingOrder;
        //    player.sortingOrder = AddSortingOrder + player.sortingOrder;
        //    player.isAbove = false;
        //}
        //else
        //{
        //    AddSortingOrder = 0;
        //    player.isAbove = true;
        //}
    }

    void FixedUpdate()
    {
        if (animator.GetBool(attackingHashCode))
        {
            myRigidbody2D.velocity = Vector2.zero;
            //myRigidbody2D.Sleep();
        }
        else
        {
            Vector2 vectorSpeed = new Vector2(horizontal, vertical) * playerAttributes.speed;
            myRigidbody2D.velocity = vectorSpeed;
        }
    }

    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }

    void attackController()
    {
        attacker.Attack(inputPlayer.faceDirection, playerAttributes.attack);
        animator.SetBool(attackingHashCode, false);
    }

    public RaycastHit2D[] Interact()
    {
        RaycastHit2D[] circleCast = Physics2D.CircleCastAll(transform.position, GetComponent<CapsuleCollider2D>().size.x, inputPlayer.faceDirection, 0.5f, interactionLayer);
        if (circleCast != null)
        {
            return circleCast;
        }
        else
        {
            return null;
        }
    }
}