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
    [SerializeField] private int baseHealth;
    [SerializeField] private int baseAttack;

    private int attackModifier;
    private int healthModifier;

    public int health { get { return baseHealth + healthModifier; } }
    public int attack { get { return baseAttack + attackModifier; } }
    public float speed;

    public void ModifyAttribute(Attribute attribute, int amount)
    {
        switch (attribute)
        {
            case Attribute.attack:
                attackModifier += amount;
                break;
            case Attribute.health:
                healthModifier += amount;
                break;
        }
    }

    public void IncreaseBaseAttack(int amount)
    {
        baseAttack += amount;
    }

    public void IncreaseBaseHealth(int amount)
    {
        baseHealth += amount;
    }

    public void ResetAttributes()
    {
        baseAttack = 1;
        baseHealth = 6;
    }
}
