using UnityEngine;
using UnityEngine.UI;

namespace Task2_2728
{

    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        Timer _timer;

        public void Initialize(Timer timer)
        {
            _timer = timer;

            _timer.OnTickPassed += OnTickPassed;

            _timer.Started += OnStarted;
        }

        private void OnDestroy()
        {
            _timer.OnTickPassed -= OnTickPassed;

            _timer.Started -= OnStarted;
        }

        private void OnStarted(float time)
        {
            _slider.value = time;
        }

        private void OnTickPassed(float time)
        {
            _slider.value = time / _timer.TimeLimit;
        }
    }
}
