using System;
using System.Collections.Generic;
using UnityEngine;

namespace Task3_2728
{
    public class EnemyCounterService : MonoBehaviour
    {
        public event Action<int> CountEnemies—hanged;

        private Dictionary<Enemy, Func<bool>> _enemiesDestroyCondition = new Dictionary<Enemy, Func<bool>>();

        private List<Enemy> _enemiesToDestroy = new List<Enemy>();

        public int EnemyCount => _enemiesDestroyCondition.Count;

        public void AddEnemy(Enemy enemy, Func<bool> destroyCondition)
        {
            _enemiesDestroyCondition.Add(enemy, destroyCondition);

            CountEnemies—hanged?.Invoke(EnemyCount);
        }

        public void DestroyByCondition()
        {
            if (_enemiesDestroyCondition.Count == 0)
                return;

            foreach (KeyValuePair<Enemy, Func<bool>> pair in _enemiesDestroyCondition)
                if (pair.Value.Invoke())
                    _enemiesToDestroy.Add(pair.Key);

            if (_enemiesToDestroy.Count == 0)
                return;

            for (int i = _enemiesToDestroy.Count - 1; i >= 0; i--)
            {
                _enemiesDestroyCondition.Remove(_enemiesToDestroy[i]);
                _enemiesToDestroy[i].Suicide();
            }

            _enemiesToDestroy.Clear();

            CountEnemies—hanged?.Invoke(EnemyCount);
        }

        public void Update()
        {
            //Debug.Log(EnemyCount);
            DestroyByCondition();
        }
    }
}