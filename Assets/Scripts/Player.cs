using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int baseAttackValue = 10;
    [SerializeField] int level = 1;
    [SerializeField] int attackPercentageIncrease = 25;
    [SerializeField] int currentExp;
    [SerializeField] int expThreshhold;
    [SerializeField] int expThreshholdIncreasePerLevel;

    // attack value is base value plus a percentage increase per level
    public int AttackValue => Mathf.CeilToInt((float)baseAttackValue * (1 + (((float)attackPercentageIncrease * ((float)level - 1f))/ 100f)));

    private void Start()
    {
        // game always starts at Level 1 with no EXP
        level = 1;
        currentExp = 0;
    }

    public void AddExp(int amount)
    {
        currentExp += amount;
        UI.DisplayText("Current EXP: " + currentExp);

        // make level up button interactable if EXP meets threshold
        UI.LevelUpButton.interactable = currentExp >= expThreshhold;
    }

    public void LevelUp()
    {
        currentExp -= expThreshhold; // remove EXP needed to reach new level
        expThreshhold += expThreshholdIncreasePerLevel; // increase EXP needed for next level
        level++;
        UI.DisplayText("Leveled up!");
        UI.DisplayText("Current Level: " + level + " Attack Power: " + AttackValue);

        UI.LevelUpButton.interactable = currentExp >= expThreshhold;

        // if player reached level 5 end the game
        if (level == 5)
        {
            UI.DisplayText("You won the game!");
            UI.AttackButton.interactable = false;
            UI.LevelUpButton.interactable= false;
        }
    }
}
