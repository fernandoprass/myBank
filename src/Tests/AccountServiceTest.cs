using API.Contracts;
using API.Implementation;
using API.Models;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Tests
{
    public class AccountServiceTest
    {
        private AccountService accountService { get; set; }

        private Mock<IAccountRepository> accountRepositoryMock;

        private Mock<ITransactionService> transactionServiceMock;

        #region Facts

        /// <summary> The AccountServiceTest class constructor </summary>
        public AccountServiceTest()
        {
            InitializeMocks();
            accountService = new AccountService(accountRepositoryMock.Object);
        }

        /// <summary> Initialize Mocks </summary>
        protected void InitializeMocks()
        {
            accountRepositoryMock = new Mock<IAccountRepository>();
            transactionServiceMock = new Mock<ITransactionService>();
        }

        [Fact]
        /// <summary> Create a new account with balance equal zero </summary>
        public void Add_ReceivedValidCustomerAndInitialCreditZero_CreateNewAccountZeroBalance()
        {
            // Arrange
            int customerId = 1;
            double initialCredit = 0.0;

            var account = GenereteAccount(customerId, initialCredit);

            accountRepositoryMock.Setup(x => x.Add(account.CustomerId, 0)).Returns(account);

            // Act
            var result = accountService.Add(customerId, initialCredit);

            // Assert
            result.Should().NotBeNull();
            result.Balance = initialCredit;
        }

        [Fact]
        /// <summary> UpdateBalance account balance increasing the value</summary>
        public void UpdateBalance_ReceivedPositiveValue_IncreaseBalance()
        {
            // Arrange
            var account = GenereteAccount(1, 100);

            double credit = 50;

            accountRepositoryMock.Setup(x => x.GetById(account.Id)).Returns(account);
            accountRepositoryMock.Setup(x => x.UpdateBalance(account.Id, account.Balance)).Returns(true);

            // Act
            var result = accountService.UpdateBalance(account.Id, credit);

            // Assert
            result.Should().Be(150);
        }

        [Fact]
        /// <summary> UpdateBalance account balance decreasing the value</summary>
        public void UpdateBalance_ReceivedNegativeValue_DecreaseBalance()
        {
            // Arrange
            var account = GenereteAccount(1, 100);

            double debit = -20;

            accountRepositoryMock.Setup(x => x.GetById(account.Id)).Returns(account);
            accountRepositoryMock.Setup(x => x.UpdateBalance(account.Id, account.Balance)).Returns(true);

            // Act
            var result = accountService.UpdateBalance(account.Id, debit);

            // Assert
            result.Should().Be(80);
        }

        #endregion

        #region Helpers
        /// <summary> Create a new Account object </summary>
        /// <param name="customerId"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        private static Account GenereteAccount(int customerId, double balance)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                Balance = balance,
                CreationDate = DateTimeOffset.UtcNow,
                CustomerId = customerId
            };
            return account;
        }

        #endregion
    }
}
