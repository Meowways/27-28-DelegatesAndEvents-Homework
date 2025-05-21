namespace Task1
{
    public class CurrencyTransactions
    {
        public void Add(CurrencyType currencyType, Wallet wallet, int currencyValue)
        {
            wallet.Currency[currencyType].Add(currencyValue);
        }

        public void Substruct(CurrencyType currencyType, Wallet wallet, int currencyValue)
        {
            wallet.Currency[currencyType].Substract(currencyValue);
        }
    }
}
