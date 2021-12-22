using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextHitGenerator))]
public class LvlExperience : MonoBehaviour
{
    private Health health;
    private PlayerController player;
    private TextHitGenerator textHitGenerator;
    private Range levelUpTextRange = new Range() { min = 0, max = 0 };

    public AttributeButton[] attributeButtons;
    public Image currentXpBar;

    public int attributePoints;
    private int xpActual;
    private int xpNextLevel;
    private float percentXpActualLevel;
    public int level { get; set; }

    public int xp
    {
        get { return xpActual; }
        set 
        { 
            xpActual = value;

            if (level > 1)
            {
                percentXpActualLevel = (float)(xp - ExperienceAccumulated(level)) / xpNextLevel;
                {
                    CheckIfLevelUp();
                }
            }
            else
            {
                percentXpActualLevel = (float)(xpActual) / xpNextLevel;
                CheckIfLevelUp();
            }
            UpdateXpBar();
            UpdateAttributePanel();
        }
    }

    void Start()
    {
        level = 1;
        health = GetComponent<Health>();
        player = GetComponent<PlayerController>();
        textHitGenerator = GetComponent<TextHitGenerator>();
        xpNextLevel = ExperienceCurve(level);
        UpdateXpBar();
        GetAttributeButton();
    }

    private int ExperienceCurve(int level)
    {
        float ExperienceFunction = (Mathf.Log(level, 3f) + 10);
        int xp = Mathf.CeilToInt(ExperienceFunction);
        
        return xp;
    }

    private int ExperienceAccumulated(int level)
    {
        int xp = 0;

        for (int i = 1; i < level; i++)
        {
            xp += ExperienceCurve(i);
        }
        
        return xp;
    }

    private void LevelUp()
    {
        level++;
        NextLevel();
        textHitGenerator.CreateTextHit(textHitGenerator.textHit, "LEVEL UP", transform, 5f, Color.cyan, levelUpTextRange, levelUpTextRange, 2f);
        SoundManager.PlaySound("levelUp");
        percentXpActualLevel = (float)(xp - ExperienceAccumulated(level)) / xpNextLevel;
    }

    private void CheckIfLevelUp()
    {
        while (percentXpActualLevel >= 1)
        {
            LevelUp();
        }
    }

    void NextLevel()
    {
        attributePoints++;
        xpNextLevel = ExperienceCurve(level);
        GetAttributeButton();
    }

    void UpdateXpBar()
    {
        if (currentXpBar)
        {
            //Vector3 scale = new Vector3((float)ActualHealth / baseHealth, 1, 1);
            //currentHealthBar.localScale = scale;
            currentXpBar.fillAmount = percentXpActualLevel;
        }
    }

    public void SubtractAttributePoint()
    {
        attributePoints--;
        GetAttributeButton();
        UpdateAttributePanel();
    }

    private void GetAttributeButton()
    {
        for (int button = 0; button < attributeButtons.Length; button++)
        {
            attributeButtons[button].EnableOrDisableButton(attributePoints);
        }

        //foreach (AttributeButton item in attributeButtons)
        //{
        //    item.EnableOrDisableButton(attributePoints);
        //}
    }

    private void UpdateAttributePanel()
    {
        AttributePanel.instance.UpdateAttributePoints(player.playerAttributes, this);
    }
}
