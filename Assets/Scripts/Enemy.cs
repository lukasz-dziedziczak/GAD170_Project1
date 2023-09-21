using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int baseHP = 5;
    [SerializeField] int additionalHpPerLevel = 5;
    [SerializeField] int level;

    float currentHP;
    float maxHP;
    Combat combat;

    private void Start()
    {
        level = Random.Range(0, 10);
        maxHP = baseHP + (additionalHpPerLevel * level);
        currentHP = maxHP;
        combat = FindObjectOfType<Combat>();
        UI.DisplayText("A new enemy has appeared");
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP < 1) combat.KillEnemy();
    }
}
