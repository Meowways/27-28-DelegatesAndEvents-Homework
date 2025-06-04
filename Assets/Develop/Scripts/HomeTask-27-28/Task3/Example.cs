using UnityEngine;

namespace Task3_2728
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private EnemyCounterService _enemyCounterService;
        [SerializeField] private Enemy _enemyPrefab;

        [SerializeField] private float _enemyMovingSpeed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                enemy.Initialize(new RandomMovementController(enemy, 2), _enemyMovingSpeed);
                _enemyCounterService.AddEnemy(enemy, () => enemy.LifeTime > 10);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                enemy.Initialize(new RandomMovementController(enemy, 2), _enemyMovingSpeed);
                _enemyCounterService.AddEnemy(enemy, () => _enemyCounterService.EnemyCount > 10);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                enemy.Initialize(new RandomMovementController(enemy, 2), _enemyMovingSpeed);
                _enemyCounterService.AddEnemy(enemy, () => enemy.IsDead);
            }
        }
    }
}