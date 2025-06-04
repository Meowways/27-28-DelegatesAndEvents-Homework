using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;

    [SerializeField] private EnemiesSettings _enemiesSetting;

    private void Awake()
    {
        CreateEnemies(_orkPrefab, _enemiesSetting.OrkSettings, 3);
        CreateEnemies(_elfPrefab, _enemiesSetting.ElfSettings, 3);
        CreateEnemies(_dragonPrefab, _enemiesSetting.DragonSettings, 3);
    }

    public void CreateEnemies(Enemy enemyPrefab, ISettings[] settings, int countEnemies)
    {
        for (int i = 0; i < countEnemies; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform);
            enemy.Initialize(settings[Random.Range(0, settings.Length)]);

            Debug.Log(nameof(enemy) + " " + enemy.GetStats());
        }
    }
}
