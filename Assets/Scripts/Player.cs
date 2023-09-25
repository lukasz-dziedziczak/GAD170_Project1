using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("Current player level, this is set to one at the start of the game")] int level = 1;
    [Header("Attack Settings")]
    [SerializeField, Tooltip("Base Attack Value amount")] int baseAttackValue = 10;
    [SerializeField, Tooltip("The percentage of the base Attack value that is added to the base amount per level")] int attackPercentageIncrease = 25;
    [Header("Experiance Settings")]
    [SerializeField, Tooltip("Current amount of experiance points, set to zero at the start")] int currentExp;
    [SerializeField, Tooltip("Experiance required before the next level")] int expThreshhold;
    [SerializeField, Tooltip("The increase in experiance points in points added to the threshold every time player levels up")] int expThreshholdIncreasePerLevel;

    /// <summary>
    /// Attack Value is base value plus a percentage increase per level
    /// </summary>
    public int AttackValue => Mathf.CeilToInt((float)baseAttackValue * (1 + (((float)attackPercentageIncrease * ((float)level - 1f))/ 100f)));

    private void Start()
    {
        // game always starts at Level 1 with no EXP
        level = 1;
        currentExp = 0;
    }

    /// <summary>
    /// Adds experiance to the player
    /// </summary>
    /// <param name="amount"></param>
    public void AddExp(int amount)
    {
        currentExp += amount;
        UI.DisplayText("Current EXP: " + currentExp);

        // make level up button interactable if EXP meets threshold
        UI.LevelUpButton.interactable = currentExp >= expThreshhold;
    }

    /// <summary>
    /// Increase the player's level 
    /// and sets up how much experiance is needed for the next level
    /// It will end the game once the player reaches level 5
    /// </summary>
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
