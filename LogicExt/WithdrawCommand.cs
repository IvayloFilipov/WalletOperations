using Services;
using LogicExt;

namespace RefactoringPlan
{
    public class WithdrawCommand : ICommand
    {
        private readonly IWallet wallet;

        public WithdrawCommand(IWallet wallet)
        {
            this.wallet = wallet;
        }

        public void Execute()
        {
            Console.Write("Enter withdrawal amount: $");

            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) && withdrawAmount > 0)
            {
                wallet.Withdraw(withdrawAmount);
            }
            else
            {
                Console.WriteLine("Invalid amount. The amount must be positive number");
            }
        }
    }
}
