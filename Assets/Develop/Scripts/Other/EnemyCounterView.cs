using TMPro;
using UnityEngine;

public class EnemyCounterView : MonoBehaviour
{
    [SerializeField] private EnemyCounterService _enemyCounterService;
    [SerializeField] private TextMeshProUGUI _countEnemiesText;

    private void Start()
    {
        _enemyCounterService.CountEnemies—hanged += OnCountEnemies—hanged;

        _countEnemiesText.text = _enemyCounterService.EnemyCount.ToString();
    }

    private void OnCountEnemies—hanged(int count)
    {
       _countEnemiesText.text = count.ToString();
    }
}
