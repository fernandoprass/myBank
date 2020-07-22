using API.Contracts;
using API.DBContexts;
using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Implementation
{
    /// <summary> The Account Repository class </summary>
    public class AccountRepository : Repository, IAccountRepository
    {
        private static string Filename => "Account";

        /// <summary> The Account Repository class constructor </summary>
        public AccountRepository() : base(Filename)
        {

        }

        /// <summary> Get the list of Account from Json file </summary>
        /// <returns></returns>
        private static List<Account> GetAccountList()
        {
            var json = DBContext.Get(Filename);
            return json != null ? JsonConvert.DeserializeObject<List<Account>>(json) : new List<Account>();
        }

        /// <inheritdoc />
        public Account GetById(Guid id)
        {
            return GetAccountList().LastOrDefault(x => x.Id == id);
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

            Save(account);
            return account;
        }

        /// <inheritdoc />
        public bool UpdateBalance(Guid id, double balance)
        {
            var accounts = GetAccountList();
            accounts.First(x => x.Id == id).Balance = balance;
            return Save(accounts);
        }
    }
}
