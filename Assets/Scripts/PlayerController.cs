using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attributes))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 3;
    private Animator animator;
    private InputPlayer inputPlayer;
    private Rigidbody2D myRigidbody2D;
    private Transform transformed;
    private float horizontal;
    private float vertical;
    private Attacker attacker;
    private Attributes playerAttributes;
    int runningHashCode;
    int attackingHashCode;

    // Start is called before the first frame update
    void Start()
    {
        inputPlayer = GetComponent<InputPlayer>();
        transformed = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAttributes = GetComponent<Attributes>();
        attacker = GetComponent<Attacker>();
        runningHashCode = Animator.StringToHash("Running");
        attackingHashCode = Animator.StringToHash("Attacking");
    }

    // Update is called once per frame
    void Update() // Game logic
    {
        horizontal = inputPlayer.horizontalAxis;
        vertical = inputPlayer.verticalAxis;

        if (horizontal!=0 || vertical!=0)
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
            attacker.Attack(new Vector2(horizontal,vertical), playerAttributes.attack);
            animator.SetTrigger("Attacking");
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

    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }

    private void FixedUpdate()
    {
        // Character movement
        Vector2 vectorVelocity = new Vector2(horizontal, vertical) * speed;
        myRigidbody2D.velocity = vectorVelocity;
    }
}
