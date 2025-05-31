using UnityEngine;

namespace Task1_2728
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private WalletView _walletView;

        private Wallet _wallet;

        private void Awake()
        {
            _wallet = new Wallet(
                new Currency(CurrencyType.Coins, 10),
                new Currency(CurrencyType.Gems, 10),
                new Currency(CurrencyType.Energy, 10));
        }

        private void Start()
        {
            _walletView.Initialize(_wallet);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _wallet.Add(CurrencyType.Coins, 250);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _wallet.Add(CurrencyType.Gems, 50);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                _wallet.Add(CurrencyType.Energy, 10);

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                foreach (CurrencyType currencyType in _wallet.Currencies.Keys)
                    _wallet.Substract(currencyType, 25);
            }
        }
    }
}
