using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributePanel : MonoBehaviour
{
    public static AttributePanel instance;
    public PlayerController player;
    public Attributes playerAttributes;

    public Text txtLevel;
    public Text txtHealth;
    public Text txtAttack;
    public Text txtSpeed;
    public Text txtAttributePoints;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateAttributePoints(Attributes attributes, LvlExperience lvlExperience)
    {
        txtLevel.text = lvlExperience.level.ToString();
        txtHealth.text = attributes.health.ToString();
        txtAttack.text = attributes.attack.ToString();
        txtSpeed.text = attributes.speed.ToString();
        txtAttributePoints.text = lvlExperience.attributePoints.ToString();
    }
}
