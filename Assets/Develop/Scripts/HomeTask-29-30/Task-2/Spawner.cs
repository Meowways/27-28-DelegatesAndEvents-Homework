using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Orc _orcPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;

    [SerializeField] private EnemiesSettings _enemiesSetting;

    private List<Enemy> _enemies = new();

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            _enemies.Add(CreateEnemy(_enemiesSetting.GetEnemySettingBy(EnemyType.Orc)));
            _enemies.Add(CreateEnemy(_enemiesSetting.GetEnemySettingBy(EnemyType.Elf)));
            _enemies.Add(CreateEnemy(_enemiesSetting.GetEnemySettingBy(EnemyType.Dragon)));
        }

        _enemies.Add(CreateEnemy(_enemiesSetting.OrcSettings[0]));

        foreach (Enemy enemy in _enemies)
            Debug.Log(enemy.ShowStats());
    }

    public Enemy CreateEnemy(ISettings settings)
    {
        switch (settings)
        {
            case OrcSettings orcSettings:
                Orc orc = Instantiate(_orcPrefab, transform);
                orc.Initialize(orcSettings);
                return orc;

            case ElfSettings elfSettings:
                Elf elf = Instantiate(_elfPrefab, transform);
                elf.Initialize(elfSettings);
                return elf;

            case DragonSettings dragonSettings:
                Dragon dragon = Instantiate(_dragonPrefab, transform);
                dragon.Initialize(dragonSettings);
                return dragon;

            default:
                throw new InvalidOperationException($"Unsupported enemy settings");
        }
    }

    [Serializable]
    public class EnemiesSettings 
    {
        [field: SerializeField] public OrcSettings[] OrcSettings;
        [field: SerializeField] public ElfSettings[] ElfSettings;
        [field: SerializeField] public DragonSettings[] DragonSettings;

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