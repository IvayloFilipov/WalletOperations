namespace Services
{
    public interface IWallet
    {
        void Deposit(decimal amount);

        void Withdraw(decimal amount);

        void PlayGame(decimal bet);
    }
}
