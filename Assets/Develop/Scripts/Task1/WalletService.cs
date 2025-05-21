using UnityEngine;

namespace Task1
{
    public class WalletService : MonoBehaviour
    {
        [SerializeField] private Sprite _coinIcon;
        [SerializeField] private int _coinStartValue;

        [SerializeField] private Sprite _gemIcon;
        [SerializeField] private int _gemStartValue;

        [SerializeField] private Sprite _energyIcon;
        [SerializeField] private int _energyStartValue;

        private Wallet _wallet;
        private CurrencyTransactions _currencyTransactions;

        private void Awake()
        {
            _wallet = new Wallet(
                new Currency(_coinIcon, CurrencyType.Coins, _coinStartValue),
                new Currency(_gemIcon, CurrencyType.Gems, _gemStartValue),
                new Currency(_energyIcon, CurrencyType.Energy, _energyStartValue));

            _currencyTransactions = new CurrencyTransactions();
        }

        public void Add(CurrencyType currencyType, int currencyValue)
            => _currencyTransactions.Add(currencyType, _wallet, currencyValue);

        public void Substract(CurrencyType currencyType, int currencyValue)
            => _currencyTransactions.Substruct(currencyType, _wallet, currencyValue);

        public Currency GetCurrencyType(CurrencyType currencyType)
            => _wallet.Currency[currencyType];

        public int GetValueBy(CurrencyType currencyType) => _wallet.Currency[currencyType].Value;

        public Sprite GetIconBy(CurrencyType currencyType) => _wallet.Currency[currencyType].Icon;
    }
}