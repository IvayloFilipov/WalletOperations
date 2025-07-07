namespace Services
{
    public class Wallet : IWallet
    {
        public decimal Balance { get; private set; }

        private Random random = new Random();

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Your deposit of ${amount} was successful. Your current balance is: ${Math.Round(Balance, 2)}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine($"Insufficient funds. Your current balance is: ${Math.Round(Balance, 2)}");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Your withdrew of ${amount} was successful. Your current balance is: ${Math.Round(Balance, 2)}");
            }
        }

        public void PlayGame(decimal bet)
        {
            if (bet > Balance)
            {
                Console.WriteLine($"You do not have enough balance to place this bet. Your current balance is: ${Math.Round(Balance, 2)}");
                return;
            }

            int betPercentages = random.Next(1, 101); // use to generate random win/loss betting % from 1 to 100
            decimal randomMultipier;
            decimal winAmount;

            if (betPercentages <= 50)
            {
                // Lose
                winAmount = 0;
                Console.WriteLine($"No luck this time!");
            }
            else if (betPercentages >= 51 && betPercentages <= 90)
            {
                // Win up to x*2 the bet amount // Range: (1.0, 2.0)
                randomMultipier = 1 + (decimal)random.NextDouble();
                winAmount = bet * randomMultipier;

                Console.WriteLine($"Congrats - you won ${winAmount:0.00}!");
            }
            else
            {
                // Win between x*2 and x*10 the bet amount // Range: (2.0, 10.0)
                randomMultipier = 2 + (decimal)(random.NextDouble() * 8);
                winAmount = bet * randomMultipier;

                Console.WriteLine($"JACKPOT! Congrats - you won ${winAmount:0.00}!");
            }

            Balance = Balance - bet + winAmount;
            Console.WriteLine($"Your current balance is ${Math.Round(Balance, 2)}");
        }
    }
}
