using LogicExt;
using Services;

namespace RefactoringPlan
{
    public class RefactoringRunTheGame
    {
        private readonly IWallet wallet;

        public RefactoringRunTheGame(IWallet wallet)
        {
            this.wallet = wallet;
        }

        public void RunTheGame()
        {
            Console.WriteLine("Hello and welcome to the Player Wallet Gaming Console!");

            Console.WriteLine("Hello and welcome to the Player Wallet Gaming Console!");
            Console.WriteLine("Please, submit an action:");
            Console.WriteLine("If you want to deposit funds press: 1");
            Console.WriteLine("If you want to withdraw funds press: 2");
            Console.WriteLine("If you want to play a game press: 3");
            Console.WriteLine("If you want to quit the game press: 4");

            var commands = new Dictionary<string, ICommand>
            {
                { "1", new DepositeCommand(wallet) },
                { "2", new WithdrawCommand(wallet) },
                { "3", new PlayGameCommand(wallet) },
                { "4", new QuitCommand() }
            };

            bool running = true;

            while (running)
            {
                Console.Write("Enter choice: ");
                string? input = Console.ReadLine()?.Trim();

                if (commands.TryGetValue(input ?? "", out var currCommand))
                {
                    currCommand.Execute();

                    if (input == "4") 
                    {
                        running = false; 
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }
}
