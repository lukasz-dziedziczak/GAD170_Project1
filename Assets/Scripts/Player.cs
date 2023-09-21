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
    [SerializeField] Button levelUpButton;


    public int AttackValue => Mathf.CeilToInt((float)baseAttackValue * (1 + (((float)attackPercentageIncrease * (level - 1))/ 100)));

    public void AddExp(int amount)
    {
        currentExp += amount;
        levelUpButton.interactable = currentExp >= expThreshhold;
        UI.DisplayText("Current EXP: " + currentExp);
    }

    public void LevelUp()
    {
        currentExp -= expThreshhold;
        expThreshhold += expThreshholdIncreasePerLevel;
        level++;
        UI.DisplayText("Leveled up!");
        UI.DisplayText("Current Level: " + level + " Attack Power: " + AttackValue);
        levelUpButton.interactable = currentExp >= expThreshhold;

        if (level == 5)
        {
            UI.DisplayText("You won the game!");
        }
    }
}
