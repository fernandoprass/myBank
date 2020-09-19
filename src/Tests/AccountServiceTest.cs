using API.Contracts;
using API.Implementation;
using API.Models;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Tests
{
	/// <summary> The Account Service unit test </summary>
    public class AccountServiceTest : BaseTest
    {
        private AccountService accountService { get; set; }

        private Mock<IAccountRepository> accountRepositoryMock;

        private Mock<IUserService> userServiceMock;

        #region Facts

        /// <summary> The AccountServiceTest class constructor </summary>
        public AccountServiceTest() : base()
        {
            InitializeMocks();
            accountService = new AccountService(accountRepositoryMock.Object
            );
        }

        /// <summary> Initialize Mocks </summary>
        protected override void InitializeMocks()
        {
            accountRepositoryMock = new Mock<IAccountRepository>();
            userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        /// <summary> Create a new account with balance equal zero </summary>
        public void Add_ReceivedValidCustomerAndInitialCreditZero_CreateNewAccountZeroBalance()
        {
            // Arrange
            int customerId = 1;
            double initialCredit = 0.0;

            var account = GenerateAccount(customerId, initialCredit);
            var user = GenerateUser(1, "Tina", "Turner");

            accountRepositoryMock.Setup(x => x.Add(account.CustomerId)).Returns(account);
            userServiceMock.Setup(x => x.GetById(customerId)).Returns(user);

            // Act
            var result = accountService.Add(customerId);

            // Assert
            result.Should().NotBeNull();
            result.Balance = initialCredit;
        }

        [Fact]
        /// <summary> UpdateBalance account balance increasing the value</summary>
        public void UpdateBalance_ReceivedPositiveValue_IncreaseBalance()
        {
            // Arrange
            var account = GenerateAccount(1, 100);

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
            var account = GenerateAccount(1, 100);

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
        private static Account GenerateAccount(int customerId, double balance)
        {
            return new Account
            {
                Id = Guid.NewGuid(),
                Balance = balance,
                CreationDate = DateTimeOffset.UtcNow,
                CustomerId = customerId
            };
        }

        /// <summary> Create a new User object </summary>
        /// <param name="customerId"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        private static User GenerateUser(int id, string name, string surname)
        {
            return new User
            {
                Id = id,
                Name = name,
                Surname = surname,
            };
        }

        #endregion
    }
}
