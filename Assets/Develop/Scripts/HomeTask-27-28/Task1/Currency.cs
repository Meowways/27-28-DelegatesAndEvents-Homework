using System;

namespace Task1_2728
{
    public class Currency 
    {
        private ReactiveVarible<int> _value;

        public Currency(CurrencyType currencyType, int value)
        {
            CurrencyType = currencyType;

            _value = new ReactiveVarible<int>(value);
        }

        public ReactiveVarible<int> Value => _value;

        public CurrencyType CurrencyType { get; private set; }

        public void Add(int value)
        {
            if (value <= 0)
                _value.Value += 0;

            _value.Value += value;
        }

        public void Substract(int value)
        {
            if (value <= 0)
                _value.Value += 0;

            _value.Value -= value;

            if (_value.Value < 0)
                _value.Value = 0;
        }
    }
}
