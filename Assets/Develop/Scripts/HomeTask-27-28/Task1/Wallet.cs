using System.Collections.Generic;

namespace Task1_2728
{
    public class Wallet
    {
        private Dictionary<CurrencyType, Currency> _currencies = new Dictionary<CurrencyType, Currency>();

        public Wallet(params Currency[] currencies)
        {
            foreach (Currency currency in currencies)
                _currencies.Add(currency.CurrencyType, currency);
        }

        public IReadOnlyDictionary<CurrencyType, Currency> Currencies => _currencies;

        public void Add(CurrencyType currencyType, int currencyValue)
            => _currencies[currencyType].Add(currencyValue);

        public void Substract(CurrencyType currencyType, int currencyValue)
            => _currencies[currencyType].Substract(currencyValue);
    }
}
