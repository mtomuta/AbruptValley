using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardController : EnemyAI
{
    public Projectile projectile;

    private void Update()
    {
        Behaviour();
    }

    public override void EnemyAttack()
    {
        ThrowProjectile(projectile, projectile.startSpeed, input.directionTowardsPlayer, attributes.attack);
        SoundManager.PlaySound("throwProjectile");
    }

    public void ThrowProjectile(Projectile projectile, float startSpeed, Vector2 direction, int damage)
    {
        Projectile newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.gameObject.transform.SetParent(transform);
        newProjectile.startSpeed = startSpeed;
        newProjectile.startDirection = direction;
        newProjectile.damage = damage;
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
        SoundManager.PlaySound("wizardDeath");
    }
}