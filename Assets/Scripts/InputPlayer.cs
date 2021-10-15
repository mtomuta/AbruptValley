using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [HideInInspector] public float horizontalAxis { get; private set; }
    [HideInInspector] public float verticalAxis { get; private set; }
    [HideInInspector] public bool attack { get; private set; }
    [HideInInspector] public bool ability { get; private set; }
    [HideInInspector] public bool interact { get; private set; }
    [HideInInspector] public bool inventory { get; private set; }

    // Update is called once per frame
    void Update()
    {
        attack = Input.GetButtonDown("Attack");
        ability = Input.GetButtonDown("Ability");
        interact = Input.GetButtonDown("Interact");
        inventory = Input.GetButtonDown("Inventory");

        // Defining movements axis
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
    }
}