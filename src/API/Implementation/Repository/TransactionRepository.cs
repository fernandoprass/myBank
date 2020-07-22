﻿using API.Contracts;
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
    public class TransactionRepository : Repository, ITransactionRepository
    {
        private static string Filename => "Transaction";

        /// <summary> The Transaction Repository class constructor </summary>
        public TransactionRepository() : base(Filename)
        {

        }

        /// <summary> Get the list of Account from Json file </summary>
        /// <returns></returns>
        private static List<Transaction> GetTransactionList()
        {
            var json = DBContext.Get(Filename);
            return json != null ? JsonConvert.DeserializeObject<List<Transaction>>(json) : new List<Transaction>();
        }

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

            Save(transaction);
            return transaction;
        }

        /// <inheritdoc />
        public IEnumerable<TransactionDto> List(Guid accountId)
        {
            return GetTransactionList().Where(x => x.AccountId == accountId)
                                        .OrderBy(x => x.Date)
                                        .Select(x => new TransactionDto(x.Date, x.Value))
                                        .ToList();
        }
    }
}
