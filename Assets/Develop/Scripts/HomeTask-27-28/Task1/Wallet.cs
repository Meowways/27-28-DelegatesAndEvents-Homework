using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1_2728
{
    public class Wallet
    {
        private Dictionary<CurrencyType, ReactiveVarible<float>> _currencies = new Dictionary<CurrencyType, ReactiveVarible<float>>();

        public Wallet(params CurrencyType[] currencies)
        {
            foreach (CurrencyType currencyType in currencies)
                _currencies.Add(currencyType, new ReactiveVarible<float>());
        }

        public Wallet(params (CurrencyType, int)[] currencies)
        {
            foreach ((CurrencyType, int) currency in currencies)
                _currencies.Add(currency.Item1, new ReactiveVarible<float>(currency.Item2));
        }

        public IReadOnlyDictionary<CurrencyType, IReadOnlyVarible<float>> Currencies =>
            _currencies.ToDictionary(
                currencie => currencie.Key,
                currencie => (IReadOnlyVarible<float>)currencie.Value);


        public void Add(CurrencyType currencyType, int currencyValue)
        {
            if (currencyValue < 0)
                throw new ArgumentOutOfRangeException(nameof(currencyValue), "Value must be greater than zero");

            _currencies[currencyType].Value += currencyValue;
        }

        public void Substract(CurrencyType currencyType, int currencyValue)
        {
            if (currencyValue < 0)
                throw new ArgumentOutOfRangeException(nameof(currencyValue), "Value must be greater than zero");

            if (_currencies[currencyType].Value - currencyValue < 0)
                throw new InvalidOperationException($"Insufficient funds for currency {currencyType}");

            _currencies[currencyType].Value -= currencyValue;
        }
    }
}
