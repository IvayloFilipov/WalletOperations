namespace Services
{
    public class Play : IPlay
    {
        private readonly IWallet wallet;

        public Play(IWallet wallet )
        {
            this.wallet = wallet;
        }

        public Task RunAsync()
        {
            RunTheGame();
            
            return Task.CompletedTask;
        }
        public void RunTheGame()
        {
            Console.WriteLine("Hello and welcome to the Player Wallet Gaming Console!");
            Console.WriteLine("Please, submit an action:");
            Console.WriteLine("If you want to deposit funds press: 1");
            Console.WriteLine("If you want to withdraw funds press: 2");
            Console.WriteLine("If you want to play a game press: 3");
            Console.WriteLine("If you want to quit the game press: 4");

            var running = true;

            while (running)
            {
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter deposit amount: $");

                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
                        {
                            wallet.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.Deposit amount must be at least $1");
                        }

                        break;

                    case "2":
                        Console.Write("Enter withdrawal amount: $");

                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) && withdrawAmount > 0)
                        {
                            wallet.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }

                        break;

                    case "3":
                        Console.Write("Enter bet amount ($1 - $10): $");

                        if (decimal.TryParse(Console.ReadLine(), out decimal betAmount) && betAmount >= 1 && betAmount <= 10)
                        {
                            wallet.PlayGame(betAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid bet amount. Must be between $1 and $10.");
                        }

                        break;

                    case "4":
                        running = false;

                        Console.WriteLine("Thank you for playing! Hope to see you again soon!");

                        break;

                    default:
                        Console.WriteLine("Invalid input option. Please try again.");

                        break;
                }
            }
        }
    }
}
