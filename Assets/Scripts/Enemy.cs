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

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP < 1) combat.KillEnemy();
    }
}
