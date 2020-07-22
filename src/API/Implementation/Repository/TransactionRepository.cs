using API.Contracts;
using API.DBContexts;
using API.Helpers;
using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Implementation
{
    /// <summary> The Transaction Repository class </summary>
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        /// <inheritdoc />
        public Transaction Add(Guid accountId, double value)
        {
            Transaction transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Date = DateTimeOffset.UtcNow,
                AccountId = accountId,
                Value = value
            };

            Add(transaction);
            return transaction;
        }

        /// <inheritdoc />
        public IEnumerable<TransactionDto> GetList(Guid accountId)
        {
            return GetData().Where(x => x.AccountId == accountId)
                            .OrderBy(x => x.Date)
                            .Select(x => new TransactionDto(x.Date, x.Value))
                            .ToList();
        }
    }
}
