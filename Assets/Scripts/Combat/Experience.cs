using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextHitGenerator))]
public class Experience : MonoBehaviour
{
    private TextHitGenerator textHitGenerator;
    private Range levelUpTextRange = new Range() { min = 0, max = 0 };

    public Image currentXpBar;
    private int attributePoints;
    private int xpActual;
    private int xpNextLevel;
    private float percentXpActualLevel;
    private int level { get; set; }

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
        }
    }

    void Start()
    {
        textHitGenerator = GetComponent<TextHitGenerator>();
        level = 1;
        xpNextLevel = ExperienceCurve(level);
        UpdateXpBar();
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
}
