using API.Contracts;
using API.Models;
using API.Repository;
using System;

namespace API.Services
{
    /// <summary> The Account Service class </summary>
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository accountRepository;

        /// <summary> the account service constructor </summary>
        /// <param name="accountRepository"></param>
        /// <param name="transactionService"></param>
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        #region Validation
        /// <summary>Check if the custormer exists</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>TRUE if the customer exists</returns>
        private bool IsValidCustomer(int customerId)
        {
            //todo Implement IsValidCustomer
            return true;
        }

        /// <summary>Check if the custormer exists</summary>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns>TRUE if the value is greater than or equal to zero</returns>
        private bool IsValidInitialCredit(double initialCredit)
        {
            return initialCredit >= 0;
        }

        /// <summary> Check the business rules to create a new account </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns></returns>
        private Response ValidateRulesToCreate(int customerId, double initialCredit)
        {
            if (!IsValidCustomer(customerId))
            {
                return Response.InvalidCustomer;
            }
            else if (!IsValidInitialCredit(initialCredit))
            {
                return Response.InvalidInitialValue;
            }
            else
            {
                return Response.Success;
            }
        }
        #endregion

        #region PublicMethods

        /// <inheritdoc />
        public Account Add(int customerId, double initialCredit)
        {
            var response = ValidateRulesToCreate(customerId, initialCredit);

            if (response.Equals(Response.Success))
            {
                return accountRepository.Add(customerId, initialCredit);
            }
            else
            {
                throw new Exception(response.Message);
            }
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
