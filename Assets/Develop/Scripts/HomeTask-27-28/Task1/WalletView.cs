using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Task1_2728
{
    public class WalletView : MonoBehaviour
    {
        private Wallet _wallet;

        [SerializeField] private CurrencyView _currencyPrefab;

        [SerializeField] private CurrenciesIcon[] _currenciesIcon;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;

            foreach (KeyValuePair<CurrencyType, IReadOnlyVarible<float>> currency in _wallet.Currencies)
            {
                CurrencyView newCurrency = Instantiate(_currencyPrefab, transform);
                newCurrency.Initialize(currency.Value, GetIconBy(currency.Key));
            }
        }

        private Sprite GetIconBy(CurrencyType currencyType) => _currenciesIcon.First(icon => icon.Type == currencyType).Icon;

        [Serializable]
        private class CurrenciesIcon
        {
            [field: SerializeField] public CurrencyType Type;
            [field: SerializeField] public Sprite Icon;
        }
    }
}
