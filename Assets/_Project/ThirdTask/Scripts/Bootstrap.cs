using System;
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
                CreateEnemy(_despawnConditions.IsLifetimeExceeded);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                CreateEnemy(_despawnConditions.IsEnemyLimitExceeded);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                CreateEnemy(_despawnConditions.IsDead);
        }

        private void CreateEnemy(Func<Enemy, EnemyDestroyer, bool> action)
        {
            _enemyDestroyer.RegisterEnemy(Instantiate(_prefab), action);
        }
    }
}
