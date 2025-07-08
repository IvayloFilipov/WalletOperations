using LogicExt;
using Services;

namespace RefactoringPlan
{
    public class DepositeCommand : ICommand
    {
        private readonly IWallet wallet;

        public DepositeCommand(IWallet wallet)
        {
            this.wallet = wallet;
        }
        public void Execute()
        {
            Console.Write("Enter deposit amount: $");

            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
            {
                wallet.Deposit(depositAmount);
            }
            else
            {
                Console.WriteLine("Invalid amount.Deposit amount must be at least $1");
            }
        }
    }
}
