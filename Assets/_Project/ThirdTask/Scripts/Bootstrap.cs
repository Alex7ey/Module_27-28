using UnityEngine;

namespace ThirdTask
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private EnemyDestroyer _enemyDestroyer;

        private DespawnConditions _despawnConditions = new();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Enemy enemy = CreateEnemy();
                _enemyDestroyer.RegisterEnemy(enemy, _despawnConditions.IsLifetimeExceeded(enemy));
            }      

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Enemy enemy = CreateEnemy();
                _enemyDestroyer.RegisterEnemy(enemy, _despawnConditions.IsEnemyLimitExceeded(_enemyDestroyer));
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Enemy enemy = CreateEnemy();
                _enemyDestroyer.RegisterEnemy(enemy, _despawnConditions.IsDead(enemy));
            }
        }

        private Enemy CreateEnemy() => Instantiate(_prefab);       
    }
}
