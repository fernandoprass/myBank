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

        private readonly IUserService userService;

        /// <summary> the account service constructor </summary>
        /// <param name="accountRepository">The account repository </param>
        /// <param name="userService">The user repository</param>
        public AccountService(IAccountRepository accountRepository,
            IUserService userService)
        {
            this.accountRepository = accountRepository;
            this.userService = userService;
        }

        #region Validation
        /// <summary>Check if the custormer exists</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>TRUE if the customer exists</returns>
        private Response IsValidCustomer(int customerId)
        {
            var user = userService.GetById(customerId);
            return user != null ? Response.Success : Response.InvalidCustomer;
        }
        #endregion

        #region PublicMethods

        /// <inheritdoc />
        public Account Add(int customerId)
        {
            var response = IsValidCustomer(customerId);

            if (response.Equals(Response.Success))
            {
                return accountRepository.Add(customerId);
            }
            else
            {
                throw new Exception(response.Message);
            }
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
        #endregion
    }
}
