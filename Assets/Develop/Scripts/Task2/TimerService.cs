using System;
using UnityEngine;

public class TimerService : MonoBehaviour
{
    public event Action<float> OnSecondPassed
    {
        add => _timer.OnSecondPassed += value;
        remove => _timer.OnSecondPassed -= value;
    }

    public event Action<float> OnTickPassed
    {
        add => _timer.OnTickPassed += value;
        remove => _timer.OnTickPassed -= value;
    }

    public event Action Started;

    public event Action Stopped;

    [SerializeField] private float _limitTime;
    [SerializeField] private bool _reverseTime;

    private Timer _timer;

    private float _t;

    public float TimeLimit => _limitTime;

    private void Awake()
    {
        _timer = new Timer(this);
    }

    public void RunTimer()
    {
        _timer.RunProcess(_limitTime, _reverseTime);

        Started?.Invoke();
    }

    public void PauseTimer() => _timer.PauseProcess();

    public void ContinueTimer() => _timer.ContinueProcess();

    public void ResetTimer()
    {
        _timer.ClearProcess();

        Stopped?.Invoke();
    }
}
