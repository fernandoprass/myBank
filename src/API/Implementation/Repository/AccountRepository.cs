using API.Contracts;
using API.DBContexts;
using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace API.Implementation
{
    /// <summary> The Account Repository class </summary>
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        /// <inheritdoc />
        public Account GetById(Guid id)
        {
            return GetData().LastOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public Account Add(int customerId)
        {
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTimeOffset.UtcNow,
                CustomerId = customerId,
                Balance = 0.0
            };

            Add(account);
            return account;
        }

        /// <inheritdoc />
        public bool UpdateBalance(Guid id, double balance)
        {
            var account = GetData();
            account.First(x => x.Id == id).Balance = balance;
            return Update(account);
        }
    }
}
