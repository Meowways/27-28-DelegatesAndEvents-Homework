using System;
using System.Collections;
using UnityEngine;

namespace Task2_2728
{

    public class Timer
    {
        public event Action<float> Started;
        public event Action Stopped;

        public event Action<float> OnTickPassed;
        public event Action<float> OnSecondPassed;

        private float _timeLimit;
        private float _elapsedTime;

        private bool _isReversed;

        private Coroutine _process;

        private MonoBehaviour _coroutineRunner;

        public Timer(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public float TimeLimit => _timeLimit;

        public float ElapsedTime => _elapsedTime;

        public bool IsRinning => _process != null;

        public void Start(float time, bool isReversed = false)
        {
            Stop();

            _timeLimit = time;
            _isReversed = isReversed;
            _elapsedTime = isReversed ? time : 0;

            _process = _coroutineRunner.StartCoroutine(_isReversed ? ReverseProcess() : Process());

            Started?.Invoke(_timeLimit);
        }

        public void Stop()
        {
            if (IsRinning == false)
                return;

            _coroutineRunner.StopCoroutine(_process);
            _process = null;

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
            float nextUpdateTime = _elapsedTime;

            while (_elapsedTime < _timeLimit)
            {
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime > _timeLimit)
                    _elapsedTime = _timeLimit;

                if ((_elapsedTime - nextUpdateTime) > 0.05f)
                {
                    OnSecondPassed?.Invoke(Mathf.Ceil(nextUpdateTime));
                    nextUpdateTime += 1f;
                }

                OnTickPassed?.Invoke(_elapsedTime);

                yield return null;
            }

            _process = null;
        }

        private IEnumerator ReverseProcess()
        {
            float nextUpdateTime = _elapsedTime;

            while (_elapsedTime > 0)
            {
                _elapsedTime -= Time.deltaTime;

                if (_elapsedTime < 0)
                    _elapsedTime = 0;

                if ((nextUpdateTime - _elapsedTime) > 0.05f)
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
}
