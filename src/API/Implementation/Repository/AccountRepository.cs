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
    public class AccountRepository : IAccountRepository
    {
        private static string Filename => "Account";

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
        public Account Add(int customerId, double initialCredit)
        {
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTimeOffset.UtcNow,
                CustomerId = customerId,
                Balance = initialCredit
            };

            var accounts = GetAccountList();

            accounts.Add(account);
            Save(accounts);
            return account;
        }

        /// <inheritdoc />
        public void UpdateBalance(Guid id, double balance)
        {
            var accounts = GetAccountList();
            accounts.First(x => x.Id == id).Balance = balance;
            Save(accounts);
        }

        /// <summary> Save data </summary>
        /// <param name="accounts"></param>
        private static void Save(IEnumerable<Account> accounts)
        {
            try
            {
                DBContext.Write(Filename, accounts);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
