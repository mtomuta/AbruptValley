using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public float horizontalAxis { get; private set; }
    public float verticalAxis { get; private set; }
    public bool attack { get; private set; }
    public bool ability { get; private set; }
    public bool interact { get; private set; }
    public bool inventory { get; private set; }

    [HideInInspector]
    public Vector2 faceDirection = new Vector2(0, -1f);

    // Update is called once per frame
    void FixedUpdate()
    {
        attack = Input.GetButtonDown("Attack");
        ability = Input.GetButtonDown("Ability");
        interact = Input.GetButtonDown("Interact");
        inventory = Input.GetButtonDown("Inventory");

        // Defining movements axis
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        determinateFaceDirection();
        Debug.DrawLine(transform.position, transform.position + (Vector3)faceDirection.normalized * 3, Color.green);
    }

    private void determinateFaceDirection()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            faceDirection.x = horizontalAxis;
            faceDirection.y = verticalAxis;
        }
    }
}