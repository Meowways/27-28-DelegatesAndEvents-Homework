using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Task1_2728
{
    public class WalletView : MonoBehaviour
    {
        private Wallet _wallet;

        [SerializeField] private Sprite _spriteCoins;
        [SerializeField] private Sprite _spriteGems;
        [SerializeField] private Sprite _spriteEnergy;

        [SerializeField] private Image _iconCoins;
        [SerializeField] private Image _iconGems;
        [SerializeField] private Image _iconEnergy;

        [SerializeField] private TextMeshProUGUI _valueCoins;
        [SerializeField] private TextMeshProUGUI _valueGems;
        [SerializeField] private TextMeshProUGUI _valueEnergy;

        private void Awake()
        {
            _iconCoins.sprite = _spriteCoins;
            _iconGems.sprite = _spriteGems;
            _iconEnergy.sprite = _spriteEnergy;
        }

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;

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

        private void OnValueChanged(CurrencyType currencyType, int value)
        {
            switch (currencyType)
            {
                case CurrencyType.Coins:
                    _valueCoins.text = value.ToString();
                    break;
                case CurrencyType.Gems:
                    _valueGems.text = value.ToString();
                    break;
                case CurrencyType.Energy:
                    _valueEnergy.text = value.ToString();
                    break;
                default:
                    Debug.LogError("A new unknown currency");
                    break;
            }
        }
    }
}
