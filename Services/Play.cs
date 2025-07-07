namespace Services
{
    public class Play : IPlay
    {
        private readonly IWallet wallet;

        // Inject IWallet (DI via constructor). Due to the IWallet three methods (Deposit, Withdraw and PlayGame) are needed here in RunTheGame().
        public Play(IWallet wallet )
        {
            this.wallet = wallet;
        }

        // Encapsulate the main logic of the game flow in a class (like in the RunTheGame() below).
        public Task RunAsync()
        {
            RunTheGame();
            
            return Task.CompletedTask;
        }

        // Encapsulated the game logic inside RunTheGame().
        private void RunTheGame()
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
                string? choice = Console.ReadLine()?.Trim();

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
                        Console.WriteLine("Invalid input option. Input cannot be empty. Please try again.");

                        break;
                }
            }
        }
    }
}
