using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    health,
    attack,
    speed
}

[CreateAssetMenu(menuName="ScriptableObjects/Attributes")]
public class Attributes : ScriptableObject
{
    [SerializeField] private int baseAttack;

    private int attackModifier;

    public int attack { get { return baseAttack + attackModifier; } }
    public float speed;

    public void IncreaseBaseAttack(int amount)
    {
        baseAttack += amount;
    }

    public void ModifyAttribute(Attribute attribute, int amount)
    {
        switch (attribute)
        {
            case Attribute.attack:
                attackModifier += amount;
                break;
            case Attribute.health:
                
                break;
        }
    }

    private void ModifyHealth(Health health, int amount)
    {
        health.healthModifier += amount;
    }
}

