using UnityEngine;

namespace Task1
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private WalletService _walletService;

        public void AddCoin() => _walletService.Add(CurrencyType.Coins, 10);

        public void AddGems() => _walletService.Add(CurrencyType.Gems, 10);

        public void AddEnergy() => _walletService.Add(CurrencyType.Energy, 10);

        public void SubstractCoin() => _walletService.Substract(CurrencyType.Coins, 10);

        public void SubstractGems() => _walletService.Substract(CurrencyType.Gems, 10);

        public void SubstractEnergy() => _walletService.Substract(CurrencyType.Energy, 10);
    }
}
