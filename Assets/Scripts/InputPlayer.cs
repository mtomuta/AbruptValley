using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    [HideInInspector] public float horizontalAxis;
    [HideInInspector] public float verticalAxis;
    [HideInInspector] public bool attack;
    [HideInInspector] public bool ability;
    [HideInInspector] public bool interact;
    [HideInInspector] public bool inventory;

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