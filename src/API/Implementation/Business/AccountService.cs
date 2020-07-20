using System;
using System.Data;
using API.Contracts;
using API.Models;

namespace API.Repository
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository accountRepository;

        private readonly ITransactionService transactionService;

        /// <summary> the account service constructor </summary>
        /// <param name="accountRepository"></param>
        /// <param name="transactionService"></param>
        public AccountService(IAccountRepository accountRepository, ITransactionService transactionService)
        {
            this.accountRepository = accountRepository;
            this.transactionService = transactionService;

        }

        #region Validation
        /// <summary>Check if the custormer exists</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>TRUE if the customer exists</returns>
        private bool IsValidCustomer(int customerId)
        {
            //todo Implement IsValidCustomer
            throw new NotImplementedException();
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
        public double UpdateBalance(Guid accountId, double value)
        {
            var account = accountRepository.GetById(accountId);
            account.Balance += value;
            account = accountRepository.Update(account);
            return account.Balance;
        }
        #endregion
    }
}
