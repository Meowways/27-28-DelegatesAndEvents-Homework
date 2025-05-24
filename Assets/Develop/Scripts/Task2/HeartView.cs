using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Task2_2728
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] private GameObject _heartPrefab;
        [SerializeField] private Transform _spawnPosition;

        [SerializeField] private Sprite _hearthA;
        [SerializeField] private Sprite _hearthB;

        private List<Image> _hearts = new List<Image>();

        private Timer _timer;

        public void Initialize(Timer timer)
        {
            _timer = timer;

            _timer.Started += OnStarted;
            _timer.Stopped += OnStopped;

            _timer.OnSecondPassed += OnSecondPassed;
        }

        private void OnDestroy()
        {
            _timer.Started -= OnStarted;
            _timer.Stopped -= OnStopped;

            _timer.OnSecondPassed -= OnSecondPassed;
        }

        private void OnStarted(float time)
        {
            if (_hearts.Count <= 0)
            {
                CreateHearths();
                OnSecondPassed(_timer.ElapsedTime);
            }
        }

        private void OnStopped()
        {
            for (int i = _hearts.Count - 1; i >= 0; i--)
                Destroy(_hearts[i].gameObject);

            _hearts.Clear();
        }

        private void OnSecondPassed(float time)
        {
            Debug.Log(time);
            for (int i = _hearts.Count - 1; i >= 0; i--)
            {
                if (i < (int)time)
                    _hearts[i].sprite = _hearthA;
                else
                    _hearts[i].sprite = _hearthB;
            }
        }

        private void CreateHearths()
        {
            for (int i = 0; i < _timer.TimeLimit; i++)
            {
                GameObject heart = Instantiate(_heartPrefab, _spawnPosition);
                _hearts.Add(heart.GetComponent<Image>());
            }
        }
    }
}