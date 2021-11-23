using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public Attributes attributes;
    private Attacker attacker;
    protected InputEnemy input;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        input = GetComponent<InputEnemy>();
    }

    public void SpikeDamage()
    {
        attacker.Attack(input.directionTowardsPlayer, attributes.attack);
    }
}
