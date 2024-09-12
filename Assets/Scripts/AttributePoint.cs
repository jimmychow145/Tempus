using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AttributePoint : MonoBehaviour
{
    public Text attributesText;
    public Text StrengthText;
    public Text EnduranceText;
    public Text VitalityText;
    public Text AgilityText;

    public int strengthPoints, endurancePoints, VitalityPoints, AgilityPoints;

    public int attributesPoints = 0;

    public CharacterStat characterStat;
    
    void Awake()
    {
        updateAttributePointText();
        strengthPoints = 0;
        
    }

    public void AddDamage()
    {
        if (attributesPoints >= 1)
        {
            characterStat.damage.AddValue(1);
            attributesPoints--;
            strengthPoints++;
            StrengthText.text = "Strength: " + strengthPoints;
            updateAttributePointText();
        }

    }

    public void AddEndurance()
    {
        if (attributesPoints >= 1)
        {
            characterStat.armor.AddValue(1);
            attributesPoints--;
            endurancePoints++;
            EnduranceText.text = "Endurance: " + endurancePoints;
            updateAttributePointText();
        }

    }

    public void AddMaxHealth()
    {
        if (attributesPoints >= 1)
        {
            characterStat.maxHealth += 1;
            characterStat.currentHealth += 1;
            attributesPoints--;
            VitalityPoints++;
            VitalityText.text = "Vitality: " + VitalityPoints;
            updateAttributePointText();
        }


    }

    public void AddSpeed()
    {
        if (attributesPoints >= 1)
        {
            characterStat.speed.AddValue(100);
            attributesPoints--;
            AgilityPoints++;
            AgilityText.text = "Agility: " + AgilityPoints;
            updateAttributePointText();
        }

    }

    public void updateAttributePointText()
    {
        attributesText.text = "Points: " + attributesPoints;
    }
}
