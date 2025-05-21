using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounterService : MonoBehaviour
{
    public event Action<int> CountEnemies—hanged;

    private List<Enemy> _enemies = new List<Enemy>();
    private List<Enemy> _enemiesToDestroy = new List<Enemy>();

    public int EnemyCount => _enemies.Count;

    public void AddEnemy(Enemy enemy, Func<Enemy, bool> destroyCondition)
    {
        enemy.DestroyCondition = destroyCondition;
        _enemies.Add(enemy);

        CountEnemies—hanged?.Invoke(EnemyCount);
    }

    public void DestroyByCondition()
    {
        if (_enemies.Count == 0)
            return;

        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            if (_enemies[i].DestroyCondition(_enemies[i]))
            {
                _enemiesToDestroy.Add(_enemies[i]);
                _enemies.RemoveAt(i);
            }
        }

        if (_enemiesToDestroy.Count == 0)
            return;

        for (int i = _enemiesToDestroy.Count - 1; i >= 0; i--)
        {
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
