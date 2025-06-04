using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Task1_2728
{
    [Serializable]
    public class CurrencyView : MonoBehaviour, IDisposable
    {
        [SerializeField] private Image _icon;

        [SerializeField] private TextMeshProUGUI _value;

        private ReactiveVarible<int> _current;

        public void Initialize(Currency currency, Sprite icon)
        {
            _current = currency.Value;
            _current.Changed += OnChangeValue;

            CurrencyUpdate(default, _current.Value);

            _icon.sprite = icon;
        }

        public void Dispose()
        {
            _current.Changed -= OnChangeValue;
        }

        public void OnChangeValue(int oldValue, int newValue) => CurrencyUpdate(_current.Value, newValue);

        private void CurrencyUpdate(int currentValue, int newValue) => _value.text = newValue.ToString();

    }
}