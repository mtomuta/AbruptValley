using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 3;
    private Animator animator;
    private InputPlayer inputPlayer;
    private Rigidbody2D myRigidbody2D;
    private Transform transformed;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        inputPlayer = GetComponent<InputPlayer>();
        transformed = GetComponent<Transform>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() // Game logic
    {
        horizontal = inputPlayer.horizontalAxis;
        vertical = inputPlayer.verticalAxis;

        if (horizontal!=0 || vertical!=0)
        {
            SetXYAnimator();
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
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
