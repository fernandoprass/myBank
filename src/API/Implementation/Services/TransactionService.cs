using API.Contracts;
using API.Models;
using System;
using System.Collections.Generic;

namespace API.Implementation
{
    /// <summary> The Transaction Service class </summary>
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        private readonly IAccountService accountService;

        public TransactionService(ITransactionRepository transactionRepository,
                                  IAccountService accountService)
        {
            this.transactionRepository = transactionRepository;
            this.accountService = accountService;
        }

        /// <inheritdoc />
        public Transaction Add(Guid accountId, double value)
        {
            var transaction = transactionRepository.Add(accountId, value);
            if (transaction != null)
            {
                accountService.UpdateBalance(accountId, value);
            }

            return transaction;
        }

        //// <inheritdoc />
        public IEnumerable<TransactionDto> GetList(Guid accountId)
        {
            return transactionRepository.GetList(accountId);
        }
    }
}
