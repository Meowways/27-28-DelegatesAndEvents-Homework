using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartView : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;

    [SerializeField] private Sprite _hearthA;
    [SerializeField] private Sprite _hearthB;

    [SerializeField] private TimerService _timerService;

    private List<Image> _hearts = new List<Image>();

    private void Start()
    {
        CreateHearths();

        _timerService.Started += OnStarted;
        _timerService.Stopped += OnStopped;

        _timerService.OnSecondPassed += OnSecondPassed;
    }

    private void OnDestroy()
    {
        _timerService.Started -= OnStarted;
        _timerService.Stopped -= OnStopped;

        _timerService.OnSecondPassed -= OnSecondPassed;
    }


    private void OnStarted()
    {
        foreach (Image heart in _hearts)
            heart.gameObject.SetActive(true);
    }

    private void OnStopped()
    {
        foreach (Image heart in _hearts)
            heart.gameObject.SetActive(false);
    }

    private void OnSecondPassed(float time)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if (i < (int)time)
                _hearts[i].sprite = _hearthA;
            else
                _hearts[i].sprite = _hearthB;
        }
    }

    private void CreateHearths()
    {
        for (int i = 0; i < _timerService.TimeLimit; i++)
        {
            GameObject heart = Instantiate(_heartPrefab, transform);
            heart.SetActive(false);
    
            _hearts.Add(heart.GetComponent<Image>());
        }
    }
}
