public class DespawnConditions
{
    private float _lifeTime;
    private int _maxEnemiesCount;

    public DespawnConditions(float lifeTime = 4, int maxEnemiesCount = 5)
    {
        _lifeTime = lifeTime;
        _maxEnemiesCount = maxEnemiesCount;
    }

    public bool IsLifetimeExceeded(Enemy enemy, EnemyDestroyer enemyDestroyer) => enemy.TimeSinceSpawn > _lifeTime;

    public bool IsEnemyLimitExceeded(Enemy enemy, EnemyDestroyer enemyDestroyer) => enemyDestroyer.EnemyDestructionRules.Count > _maxEnemiesCount;

    public bool IsDead(Enemy enemy, EnemyDestroyer enemyDestroyer) => enemy.IsDead;
}
