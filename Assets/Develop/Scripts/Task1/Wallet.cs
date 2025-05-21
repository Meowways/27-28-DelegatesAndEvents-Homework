using System.Collections.Generic;

namespace Task1
{
    public class Wallet
    {
        private Dictionary<CurrencyType, Currency> _currency = new Dictionary<CurrencyType, Currency>();

        public Wallet(Currency coin, Currency gem, Currency energy)
        {
            _currency.Add(CurrencyType.Coins, coin);
            _currency.Add(CurrencyType.Gems, gem);
            _currency.Add(CurrencyType.Energy, energy);
        }

        public Dictionary<CurrencyType, Currency> Currency => _currency;
    }
}
