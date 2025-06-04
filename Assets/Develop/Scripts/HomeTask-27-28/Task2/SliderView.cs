using UnityEngine;
using UnityEngine.UI;

namespace Task2_2728
{
    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private ReactiveVarible<float> _timeLimit;
        private ReactiveVarible<float> _elapsedTime;

        public void Initialize(ReactiveVarible<float> elapsedTime, ReactiveVarible<float> timeLimit)
        {
            _elapsedTime = elapsedTime;
            _timeLimit = timeLimit;

            _elapsedTime.Changed += OnTimeChanged;

            SliderUpdate(_elapsedTime.Value, _timeLimit.Value);
        }

        private void OnDestroy()
        {
            _elapsedTime.Changed -= OnTimeChanged;
        }

        private void OnTimeChanged(float oldtime, float newTime) => SliderUpdate(newTime, _timeLimit.Value);

        private void SliderUpdate(float currentTime, float limitTime) => _slider.value = currentTime / limitTime;
    }
}
