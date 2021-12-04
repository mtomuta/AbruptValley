using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : EnemyAI
{
    private void Update()
    {
        Behaviour();
    }

    protected override void Dead()
    {
        dead = true;
        animator.SetBool(deathHashCode, true);
        SoundManager.PlaySound("skeletonDeath");
    }
}