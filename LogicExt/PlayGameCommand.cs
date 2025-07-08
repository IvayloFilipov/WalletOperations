using Services;
using LogicExt;

namespace RefactoringPlan
{
    public class PlayGameCommand : ICommand
    {
        private readonly IWallet wallet;

        public PlayGameCommand(IWallet wallet)
        {
            this.wallet = wallet;
        }

        public void Execute()
        {
            Console.Write("Enter bet amount ($1 - $10): $");

            if (decimal.TryParse(Console.ReadLine(), out decimal betAmount) && betAmount >= 1 && betAmount <= 10)
            {
                wallet.PlayGame(betAmount);
            }
            else
            {
                Console.WriteLine("Invalid bet amount. Must be between $1 and $10.");
            }
        }
    }
}
