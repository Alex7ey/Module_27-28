using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    public Dictionary<Enemy, Func<Enemy, EnemyDestroyer, bool>> EnemyDestructionRules { get; private set; } = new();

    private List<Enemy> _enemiesToDestroy = new();

    public void RegisterEnemy(Enemy enemy, Func<Enemy, EnemyDestroyer, bool> action)
    {
        EnemyDestructionRules.Add(enemy, action);
    }

    private void Update()
    {
        ProcessEnemyDestruction();
        ShowEnemyCount(EnemyDestructionRules.Count);
    }

    private void ProcessEnemyDestruction()
    {
        MarkEnemiesForDestruction();
        DestroyMarkedEnemies();
    }

    private void MarkEnemiesForDestruction()
    {
        foreach (var enemy in EnemyDestructionRules)
        {
            if (enemy.Value.Invoke(enemy.Key, this))
            {
                _enemiesToDestroy.Add(enemy.Key);
            }
        }
    }

    private void DestroyMarkedEnemies()
    {
        foreach (var enemy in _enemiesToDestroy)
        {
            EnemyDestructionRules.Remove(enemy);

            Destroy(enemy.gameObject);
        }

        _enemiesToDestroy.Clear();
    }

    private void ShowEnemyCount(int value)
    {
        Debug.Log($"{value} врагов в сервисе");
    }
}
