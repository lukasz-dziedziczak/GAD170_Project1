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
        int exp = Random.Range(1, maxExpAwarded + 1);
        UI.DisplayText("You have been awarded " + exp + " EXP");
        player.AddExp(exp);
        Destroy(enemy.gameObject);
        SpawnEnemy();
    }

    public void PlayerAttack()
    {
        UI.DisplayText("You attacked dealing " + player.AttackValue + " damage.");
        enemy.TakeDamage(player.AttackValue);
    }
}
