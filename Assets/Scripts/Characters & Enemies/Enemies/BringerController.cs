using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerController : EnemyAI
{
    private void Update()
    {
        Behaviour();
    }

    protected override void FlipSprite()
    {
        if (input.horizontal < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    protected override void Dead()
    {
        dead = true;
        animator.SetBool(deathHashCode, true);
        SoundManager.PlaySound("bringerDeath");
    }
}
