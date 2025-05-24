using UnityEngine;

namespace Task2_2728
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private HeartView _heartView;
        [SerializeField] private SliderView _sliderView;

        [SerializeField] private float _limitTime;
        [SerializeField] private bool _reverseTime;

        private Timer _timer;

        private void Awake()
        {
            _timer = new Timer(this);

            _heartView.Initialize(_timer);
            _sliderView.Initialize(_timer);
        }

        public void RunTimer() => _timer.Start(_limitTime, _reverseTime);

        public void PauseTimer() => _timer.Pause();

        public void ContinueTimer() => _timer.Resume();

        public void ResetTimer() => _timer.Stop();
    }
}
