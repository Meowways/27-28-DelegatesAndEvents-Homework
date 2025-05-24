using System;
using UnityEngine;

namespace Task1_2728
{
    public class Currency
    {
        public event Action<CurrencyType, int> CurrencyChanged;

        private int _value;

        public Currency(CurrencyType currencyType, int value = 0)
        {
            CurrencyType = currencyType;

            _value = value;
        }

        public Sprite Icon { get; }

        public CurrencyType CurrencyType { get; private set; }

        public int Value => _value;

        public void Add(int value)
        {
            if (value <= 0)
                _value += 0;

            _value += value;

            CurrencyChanged?.Invoke(CurrencyType, _value);
        }

        public void Substract(int value)
        {
            if (value <= 0)
                _value += 0;

            _value -= value;

            if (_value < 0)
                _value = 0;

            CurrencyChanged?.Invoke(CurrencyType, _value);
        }
    }
}
