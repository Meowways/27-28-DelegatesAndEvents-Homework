using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Task2_2728
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] private GameObject _heartPrefab;

        [SerializeField] private Sprite _hearthA;
        [SerializeField] private Sprite _hearthB;

        private List<Image> _hearts = new List<Image>();

        private Timer _timer;

        private ReactiveVarible<float> _timeLimit;
        private ReactiveVarible<float> _elapsedTime;

        public void Initialize(Timer timer, ReactiveVarible<float> elapsedTime, ReactiveVarible<float> timeLimit)
        {
            _timer = timer;

            _elapsedTime = elapsedTime;
            _timeLimit = timeLimit;

            _elapsedTime.Changed += OnTimeChanged;

            _timer.Started += OnStarted;
            _timer.Stopped += OnStopped;
        }

        private void OnDestroy()
        {
            _elapsedTime.Changed -= OnTimeChanged;

            _timer.Started -= OnStarted;
            _timer.Stopped -= OnStopped;
        }

        private void OnTimeChanged(float oldTime, float currentTime) => DrawHearts(currentTime);

        private void OnStarted(float heartsCount) => CreateHearts(heartsCount);

        private void OnStopped() => DestroyHearts();

        private void CreateHearts(float heartsCount)
        {
            for (int i = 0; i < heartsCount; i++)
            {
                GameObject heart = Instantiate(_heartPrefab, transform);
                _hearts.Add(heart.GetComponent<Image>());
            }
        }

        private void DestroyHearts()
        {
            foreach (Image heart in _hearts)
                Destroy(heart.gameObject);

            _hearts.Clear();
        }

        private void DrawHearts(float currentTime)
        {
            for (int i = 0; i < _timeLimit.Value; i++)
                if (currentTime > i)
                    _hearts[i].sprite = _hearthA;
                else
                    _hearts[i].sprite = _hearthB;
        }
    }
}