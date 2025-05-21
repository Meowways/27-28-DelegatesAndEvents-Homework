using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Task1
{
    public class ExampleView : MonoBehaviour
    {
        [SerializeField] private WalletService _walletService;

        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private Image _coinIcon;

        [SerializeField] private TextMeshProUGUI _gemText;
        [SerializeField] private Image _gemIcon;

        [SerializeField] private TextMeshProUGUI _energyText;
        [SerializeField] private Image _energyIcon;

        private void Start()
        {
            _walletService.GetCurrencyType(CurrencyType.Coins).CurrencyChanged += OnCoinsChanged;
            _walletService.GetCurrencyType(CurrencyType.Gems).CurrencyChanged += OnGemsChanged;
            _walletService.GetCurrencyType(CurrencyType.Energy).CurrencyChanged += OnEnergyChanged;

            UpdateÑurrencyUI();
        }

        private void OnDestroy()
        {
            _walletService.GetCurrencyType(CurrencyType.Coins).CurrencyChanged -= OnCoinsChanged;
            _walletService.GetCurrencyType(CurrencyType.Gems).CurrencyChanged -= OnGemsChanged;
            _walletService.GetCurrencyType(CurrencyType.Energy).CurrencyChanged -= OnEnergyChanged;
        }

        private void UpdateÑurrencyUI()
        {
            _coinIcon.sprite = _walletService.GetIconBy(CurrencyType.Coins);
            _coinText.text = _walletService.GetValueBy(CurrencyType.Coins).ToString();

            _gemIcon.sprite = _walletService.GetIconBy(CurrencyType.Gems);
            _gemText.text = _walletService.GetValueBy(CurrencyType.Gems).ToString();

            _energyIcon.sprite = _walletService.GetIconBy(CurrencyType.Energy);
            _energyText.text = _walletService.GetValueBy(CurrencyType.Energy).ToString();
        }

        private void OnCoinsChanged(int coinsValue)
            => _coinText.text = coinsValue.ToString();

        private void OnGemsChanged(int gemsValue)
            => _gemText.text = gemsValue.ToString();

        private void OnEnergyChanged(int energyValue)
            => _energyText.text = energyValue.ToString();
    }
}
