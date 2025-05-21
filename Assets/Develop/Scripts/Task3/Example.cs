using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private EnemyCounterService _enemyCounterService;
    [SerializeField] private Enemy _enemyPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            _enemyCounterService.AddEnemy(enemy, enemy => enemy.LifeTime > 10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            _enemyCounterService.AddEnemy(enemy, enemy => _enemyCounterService.EnemyCount > 10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            _enemyCounterService.AddEnemy(enemy, enemy => enemy.IsDead);
        }
    }
}
