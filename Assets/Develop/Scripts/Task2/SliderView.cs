using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;

    [SerializeField] private TimerService _timerService;

    private void Start()
    {
        _timerService.OnTickPassed += OnTickPassed;

        _timerService.Stopped += OnStopped;
    }

    private void OnDestroy()
    {
        _timerService.OnTickPassed -= OnTickPassed;

        _timerService.Stopped -= OnStopped;
    }

    private void OnStopped()
    {
        _slider.value = _timerService.TimeLimit;
        _text.text = _timerService.TimeLimit.ToString("0.0");
    }

    private void OnTickPassed(float time)
    {
        _slider.value = time / _timerService.TimeLimit;
        _text.text = time.ToString("0.0");
    }
}
