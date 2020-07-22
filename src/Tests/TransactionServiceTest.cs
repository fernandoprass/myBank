using API.Contracts;
using API.Implementation;
using API.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
	/// <summary> The Transaction Service unit test </summary>
    public class TransactionServiceTest : BaseTest
    {
        private TransactionService transactionService { get; set; }

        private Mock<ITransactionRepository> transactionRepositoryMock;

        private readonly DateTimeOffset FirstDateTime = new DateTimeOffset(DateTime.UtcNow.AddDays(-10));

        #region Facts

        /// <summary> The AccountServiceTest class constructor </summary>
        public TransactionServiceTest()
        {
            transactionService = new TransactionService(transactionRepositoryMock.Object);
        }

        /// <summary> Initialize Mocks </summary>
        protected override void InitializeMocks()
        {
            transactionRepositoryMock = new Mock<ITransactionRepository>();
        }

        [Fact]
        /// <summary> List the transactions </summary>
        public void List_ReturnListOfTransaction()
        {
            // Arrange
            var account = GenereteAccount(1, 0.0);
            var transactions = new List<TransactionDto>
            {
                new TransactionDto(FirstDateTime, 100),
                new TransactionDto(FirstDateTime.AddDays(1), 200),
                new TransactionDto(FirstDateTime.AddDays(2), 300)
            };

            transactionRepositoryMock.Setup(x => x.List(account.Id)).Returns(transactions);

            // Act
            var result = transactionService.List(account.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result.First().Date.Should().Be(FirstDateTime);
            result.First().Value.Should().Be(100);
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
