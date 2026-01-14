using System;

public class DespawnConditions
{
    private float _lifeTime;
    private int _maxEnemiesCount;

    public DespawnConditions(float lifeTime = 4, int maxEnemiesCount = 5)
    {
        _lifeTime = lifeTime;
        _maxEnemiesCount = maxEnemiesCount;
    }

    public Func<bool> IsLifetimeExceeded(Enemy enemy) => () => enemy.TimeSinceSpawn > _lifeTime;

    public Func<bool> IsEnemyLimitExceeded(EnemyDestroyer enemyDestroyer) => () => enemyDestroyer.EnemyDestructionRules.Count > _maxEnemiesCount;

    public Func<bool> IsDead(Enemy enemy) => () => enemy.IsDead;
}
