using Services;

namespace PlayerWalletOperations.Test
{
    public class WalletTests
    {
        [Fact]
        public void Deposit_ShouldIncreaseBalance()
        {
            // Arrange
            var wallet = new Wallet();
            var initialBalance = wallet.Balance;

            // Act
            wallet.Deposit(100);

            // Assert
            Assert.Equal(initialBalance + 100, wallet.Balance);
        }

        [Fact]
        public void Withdraw_ShouldDecreaseBalance_WhenSufficientFunds()
        {
            // Arrange
            var wallet = new Wallet();
            wallet.Deposit(200);

            // Act
            wallet.Withdraw(50);

            // Assert
            Assert.Equal(150, wallet.Balance);
        }

        [Fact]
        public void Withdraw_ShouldNotChangeBalance_WhenInsufficientFunds()
        {
            // Arrange
            var wallet = new Wallet();
            wallet.Deposit(50);

            // Act
            wallet.Withdraw(100);

            // Assert
            Assert.Equal(50, wallet.Balance); // Balance should remain unchanged
        }

        [Fact]
        public void PlayGame_ShouldNotAllowBetMoreThanBalance()
        {
            // Arrange
            var wallet = new Wallet();
            wallet.Deposit(10);

            // Act
            wallet.PlayGame(100); // Bet more than balance

            // Assert
            Assert.Equal(10, wallet.Balance); // Balance should not change
        }

        [Fact]
        public void PlayGame_ShouldChangeBalance_AfterValidBet()
        {
            // Arrange
            var wallet = new Wallet();
            wallet.Deposit(100);
            var initial = wallet.Balance;

            // Act
            wallet.PlayGame(10);

            // Assert
            Assert.NotEqual(initial, wallet.Balance); // Might win or lose
        }
    }
}