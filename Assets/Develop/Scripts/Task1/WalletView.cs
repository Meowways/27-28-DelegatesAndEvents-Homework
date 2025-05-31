using System.Collections.Generic;
using UnityEngine;

namespace Task1_2728
{
    public class WalletView : MonoBehaviour
    {
        private Wallet _wallet;

        [SerializeField] private GameObject _currencyPrefab;

        [SerializeField] private Sprite[] _icon;

        private Dictionary<CurrencyType, CurrencyView> _currencies = new Dictionary<CurrencyType, CurrencyView>();

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;

            CurrenciesView();

            foreach (Currency currency in _wallet.Currencies.Values)
            {
                currency.CurrencyChanged += OnValueChanged;
                OnValueChanged(currency.CurrencyType, currency.Value);
            }

        }

        private void OnDestroy()
        {
            foreach (Currency currency in _wallet.Currencies.Values)
                currency.CurrencyChanged -= OnValueChanged;
        }

        private void CurrenciesView()
        {
            foreach (CurrencyType type in _wallet.Currencies.Keys)
            {
                CurrencyView currency = Instantiate(_currencyPrefab, transform).GetComponent<CurrencyView>();
                currency.Initialize(type, _icon[(int)type]);

                _currencies.Add(type, currency);
            }
        }

        private void OnValueChanged(CurrencyType currencyType, int value) => _currencies[currencyType].OnChangeValue(value);
    }
}
