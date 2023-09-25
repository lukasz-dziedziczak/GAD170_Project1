using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField, Tooltip("Referance to the player object")] Player player;
    [SerializeField, Tooltip("Referance to the enemy prefab")] Enemy enemyPrefab;
    [Header("Settings")]
    [SerializeField,Tooltip("The minimum amount of experiance that is awarded when an enemy dies.")] int minExpAwarded = 10;
    [SerializeField, Tooltip("The maximum (inclusive) amount of experiance that is awarded when an enemy dies.")] int maxExpAwarded = 100;

    Enemy enemy;

    private void Start()
    {
        SpawnEnemy();
    }

    /// <summary>
    /// Spawns a new enemy, note only one should be spawned at a time.
    /// We are only keeping a refence to one instance of an enemy at a time.
    /// </summary>
    public void SpawnEnemy()
    {
        enemy = Instantiate(enemyPrefab);
    }

    /// <summary>
    /// Kills the enemy, this should be called when the enemy runs out of health
    /// </summary>
    public void KillEnemy()
    {
        UI.DisplayText("Enemy has been slained.");

        // calculate and apply EXP
        int exp = Random.Range(minExpAwarded, maxExpAwarded + 1);
        UI.DisplayText("You have been awarded " + exp + " EXP");
        player.AddExp(exp);

        // destroy enemy object and spawn a new one
        Destroy(enemy.gameObject);
        SpawnEnemy();
    }

    /// <summary>
    /// Player's attack function
    /// </summary>
    public void PlayerAttack()
    {
        UI.DisplayText("You attacked dealing " + player.AttackValue + " damage.");

        // apply player's attack value as damage to enemy
        enemy.TakeDamage(player.AttackValue);
    }
}
