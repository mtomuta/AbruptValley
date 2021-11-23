using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    private bool destroyed;
    private int destroyHashCode;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        destroyHashCode = Animator.StringToHash("Destroyed");
    }

    public void Destroy()
    {
        animator.SetBool(destroyHashCode, true);
    }
}
