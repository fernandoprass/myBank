using API.Contracts;
using API.Helpers;
using API.Models;
using System;

namespace API.Implementation
{
    /// <summary> The Account Service class </summary>
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        /// <summary> the account service constructor </summary>
        /// <param name="accountRepository">The account repository </param>
        /// <param name="userService">The user repository</param>
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        /// <inheritdoc />
        public Account Add(int customerId)
        {
             return accountRepository.Add(customerId);
        }

        /// <inheritdoc />
        public Account GetById(Guid id)
        {
            return accountRepository.GetById(id);
        }

        /// <inheritdoc />
        public double UpdateBalance(Guid id, double value)
        {
            var account = accountRepository.GetById(id);
            account.Balance += value;
            accountRepository.UpdateBalance(id, account.Balance);
            return account.Balance;
        }
    }
}
