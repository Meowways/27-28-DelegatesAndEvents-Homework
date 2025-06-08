using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyPrefabs[] _enemyPrefabs;
    [SerializeField] private EnemiesSettings _enemiesSetting;

    private void Awake()
    {
        SpawnEnemiesBy(EnemyType.Orc, 3);
        SpawnEnemiesBy(EnemyType.Elf, 3);
        SpawnEnemiesBy(EnemyType.Dragon, 3);
    }

    private void SpawnEnemiesBy(EnemyType enemyType, int countEnemies)
    {
        for (int i = 0; i < countEnemies; i++)
            CreateEnemy(enemyType);
    }

    private void CreateEnemy(EnemyType enemyType)
    {
        Enemy newEnemy = Instantiate(_enemyPrefabs.First(enemy => enemy.Type == enemyType).EnemyPrefab, transform);
        newEnemy.Initialize(_enemiesSetting.GetEnemySettingBy(enemyType));

        Debug.Log(newEnemy.GetStats());
    }

    [Serializable]
    private class EnemyPrefabs
    {
        [field: SerializeField] public EnemyType Type;
        [field: SerializeField] public Enemy EnemyPrefab;
    }

    [Serializable]
    public class EnemiesSettings 
    {
        [field: SerializeField] private OrcSettings[] OrcSettings;
        [field: SerializeField] private ElfSettings[] ElfSettings;
        [field: SerializeField] private DragonSettings[] DragonSettings;

        public ISettings GetEnemySettingBy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Orc:
                    return OrcSettings[Random.Range(0, OrcSettings.Length)];

                case EnemyType.Elf:
                    return ElfSettings[Random.Range(0, ElfSettings.Length)];

                case EnemyType.Dragon:
                    return DragonSettings[Random.Range(0, DragonSettings.Length)];

                default:
                    throw new ArgumentException($"Unsupported enemy type: {enemyType}");
            }
        }
    }
}