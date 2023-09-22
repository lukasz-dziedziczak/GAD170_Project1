using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] int minExpAwarded = 10;
    [SerializeField] int maxExpAwarded = 100;

    Enemy enemy;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        enemy = Instantiate(enemyPrefab);
    }

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

    public void PlayerAttack()
    {
        UI.DisplayText("You attacked dealing " + player.AttackValue + " damage.");

        // apply player's attack value as damage to enemy
        enemy.TakeDamage(player.AttackValue);
    }
}
