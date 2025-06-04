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

        [SerializeField] private CurrenciesIcon[] _currencyIcon;

        private List<CurrencyView> _currenciesView = new();

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;

            foreach (Currency currency in _wallet.Currencies.Values)
            {
                CurrencyView currencyView = Instantiate(_currencyPrefab, transform);
                currencyView.Initialize(currency, GetIconBy(currency.CurrencyType));

                _currenciesView.Add(currencyView);
            }
        }

        private void OnDestroy()
        {
            foreach (CurrencyView currencyView in _currenciesView)
                currencyView.Dispose();
        }

        private Sprite GetIconBy(CurrencyType currencyType) => _currencyIcon.First(icon => icon.Type == currencyType).Icon;

        [Serializable]
        private class CurrenciesIcon
        {
            [field: SerializeField] public CurrencyType Type;
            [field: SerializeField] public Sprite Icon;
        }
    }
}
