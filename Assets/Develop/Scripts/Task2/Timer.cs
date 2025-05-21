using System;
using System.Collections;
using UnityEngine;

public class Timer 
{
    public event Action<float> OnTickPassed;
    public event Action<float> OnSecondPassed;

    private float _timeLimit;
    private float _elapsedTime;
    private float _pauseTime;

    private bool _isReversed;
    private bool _isPaused;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _process;

    public Timer(MonoBehaviour coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public float TimeLimit => _timeLimit;

    public float ElapsedTime => _elapsedTime;

    public void RunProcess(float time, bool isReversed)
    {
        _timeLimit = time;
        _isReversed = isReversed;

        if (_process == null)
        {
            if (_isReversed)
            {
                _elapsedTime = _timeLimit;
                _process = _coroutineRunner.StartCoroutine(ReverseProcess());
            }
            else
            {
                _elapsedTime = 0;
                _process = _coroutineRunner.StartCoroutine(Process());
            }
        }
    }

    public void PauseProcess()
    {
        if (_process != null && _isPaused == false)
            _coroutineRunner.StopCoroutine(_process);

        _pauseTime = _elapsedTime;
        _isPaused = true;
    } 

    public void ContinueProcess()
    {
        if (_process != null && _isPaused == true)
        {
            if (_isReversed)
            {
                _elapsedTime = _pauseTime;
                _process = _coroutineRunner.StartCoroutine(ReverseProcess());

                _isPaused = false;
            }
            else
            {
                _elapsedTime = _pauseTime;
                _process = _coroutineRunner.StartCoroutine(Process());

                _isPaused = false;
            }
        }
    }

    public void ClearProcess()
    {
        if (_process != null)
            _coroutineRunner.StopCoroutine(_process);

        _process = null;

        _isPaused = false;
    }

    private IEnumerator Process()
    {
        float nextUpdateTime = 0;

        while (_elapsedTime < _timeLimit)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _timeLimit)
                _elapsedTime = _timeLimit;

            if (_elapsedTime >= nextUpdateTime)
            {
                OnSecondPassed?.Invoke(nextUpdateTime);
                nextUpdateTime += 1f;
            }

            OnTickPassed?.Invoke(_elapsedTime); 

            yield return null;
        }

        _process = null;
    }

    private IEnumerator ReverseProcess()
    {
        float nextUpdateTime = _timeLimit;

        while (_elapsedTime > 0)
        {
            _elapsedTime -= Time.deltaTime;

            if (_elapsedTime < 0)
                _elapsedTime = 0;

            if (_elapsedTime <= nextUpdateTime)
            {
                OnSecondPassed?.Invoke(nextUpdateTime);
                nextUpdateTime -= 1f;
            }

            OnTickPassed?.Invoke(_elapsedTime);

            yield return null;
        }

        _process = null;
    }
}
