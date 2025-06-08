using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Task1_2728
{
    [Serializable]
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        [SerializeField] private TextMeshProUGUI _value;

        private IReadOnlyVarible<float> _current;

        public void Initialize(IReadOnlyVarible<float> curerency, Sprite icon)
        {
            _current = curerency;
            _current.Changed += OnChangeValue;

            CurrencyUpdate(default, _current.Value);

            _icon.sprite = icon;
        }

        private void OnDestroy()
        {
            _current.Changed -= OnChangeValue;
        }

        private void OnChangeValue(float oldValue, float newValue) => CurrencyUpdate(_current.Value, newValue);

        private void CurrencyUpdate(float currentValue, float newValue) => _value.text = newValue.ToString();

    }
}