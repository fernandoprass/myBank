using API.Contracts;
using API.Models;
using System;
using System.Collections.Generic;

namespace API.Repository
{
    /// <summary>The Account Business Service</summary>
    /// 
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        /// <inheritdoc />
        public Transaction Add(Guid accountId, double value)
        {
            return transactionRepository.Add(accountId, value);
        }

        //// <inheritdoc />
        public IEnumerable<TransactionListDto> List(Guid accountId)
        {
            return transactionRepository.List(accountId);
        }
    }
}
