using System;
using System.Collections;
using UnityEngine;

namespace Task2_2728
{

    public class Timer
    {
        public event Action<float> Started;
        public event Action Stopped;

        private ReactiveVarible<float> _timeLimit;
        private ReactiveVarible<float> _elapsedTime;

        private bool _isReversed;

        private Coroutine _process;

        private MonoBehaviour _coroutineRunner;

        public Timer(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;

            _elapsedTime = new ReactiveVarible<float>(0);
            _timeLimit = new ReactiveVarible<float>(1);
        }

        public ReactiveVarible<float> TimeLimit => _timeLimit;

        public ReactiveVarible<float> ElapsedTime => _elapsedTime;

        public bool IsRinning => _process != null;

        public void Start(float time, bool isReversed = false)
        {
            Stop();

            Started?.Invoke(time);

            _timeLimit.Value = time;

            _isReversed = isReversed;

            if (_isReversed == true)
            {
                _elapsedTime.Value = _timeLimit.Value;
                _process = _coroutineRunner.StartCoroutine(ReverseProcess());
            }
            else
            {
                _elapsedTime.Value = 0;
                _process = _coroutineRunner.StartCoroutine(Process());
            }
        }

        public void Stop()
        {
            if (IsRinning == false)
                return;

            _coroutineRunner.StopCoroutine(_process);
            _process = null;

            _elapsedTime.Value = 0;
            _timeLimit.Value = _elapsedTime.Value + 1;

            Stopped?.Invoke();
        }

        public void Pause()
        {
            if (IsRinning == false)
                return;

            _coroutineRunner.StopCoroutine(_process);
            _process = null;
        }

        public void Resume()
        {
            if (IsRinning)
                return;

            _process = _coroutineRunner.StartCoroutine(_isReversed ? ReverseProcess() : Process());
        }


        private IEnumerator Process()
        {
            while (_elapsedTime.Value < _timeLimit.Value)
            {
                Debug.Log(_elapsedTime.Value);
                _elapsedTime.Value += Time.deltaTime;

                if (_elapsedTime.Value > _timeLimit.Value)
                    _elapsedTime = _timeLimit;

                yield return null;
            }

            //_process = null;
        }

        private IEnumerator ReverseProcess()
        {
            while (_elapsedTime.Value > 0)
            {
                _elapsedTime.Value -= Time.deltaTime;

                if (_elapsedTime.Value < 0)
                    _elapsedTime.Value = 0;

                yield return null;
            }

            //_process = null;
        }
    }
}
