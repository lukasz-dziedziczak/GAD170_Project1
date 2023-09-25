using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Tooltip("Base amount of Health Points an enemy starts with")] int baseHP = 5;
    [SerializeField, Tooltip("Multipled by the level, how much health is added to the base amount")] int additionalHpPerLevel = 5;

    [Header("Debug")]
    [SerializeField, Tooltip("Current enemy level, randomly set on enemy spawn")] int level;

    float currentHP;
    float maxHP;
    Combat combat;

    private void Awake()
    {
        combat = FindObjectOfType<Combat>();
    }

    private void Start()
    {
        // generate random enemy level
        level = Random.Range(0, 10);

        // set health based on enemy level
        maxHP = baseHP + (additionalHpPerLevel * level);
        currentHP = maxHP;
        
        UI.DisplayText("A new enemy has appeared");
    }

    /// <summary>
    /// Called when Enemy is to take damage from player's attack
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP < 1) combat.KillEnemy();
    }
}
