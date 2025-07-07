namespace Services
{
    public interface IWallet
    {
        // Adding money to the wallet.
        void Deposit(decimal amount);

        // Removing money from the wallet.
        void Withdraw(decimal amount);

        // Represents placing a bet and deducting the bet amount.
        void PlayGame(decimal bet);
    }
}
