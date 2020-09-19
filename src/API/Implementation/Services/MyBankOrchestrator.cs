using API.Contracts;
using API.Helpers;
using API.Models;
using API.Exceptions;
using API.Models.Dto;
using System;

namespace API.Implementation
{
    /// <summary> The MyBank Orchestrator class </summary>
    public class MyBankOrchestrator : IMyBankOrchestrator
    {
        private readonly IAccountService accountService;

        private readonly ITransactionService transactionService;

        private readonly IUserService userService;

        /// <summary> The MyBank Orchestrator class constructor </summary>
        public MyBankOrchestrator(IAccountService accountService,
            ITransactionService transactionService,
            IUserService userService)
        {
            this.accountService = accountService;
            this.transactionService = transactionService;
            this.userService = userService;
        }

        /// <inheritdoc />
        public Account AddAccount(int customerId, double initialCredit)
        {
            var response = IsValidCustomer(customerId);

            if (response.Equals(Response.Success))
            {
                var account = accountService.Add(customerId);
                if (!initialCredit.NearlyEqual(0))
                {
                    transactionService.Add(account.Id, initialCredit);
                }

                return accountService.GetById(account.Id);
            }
            else
            {
                throw new MyBankException(response);
            }
        }

        /// <inheritdoc />
        public StatementDto GetStatement(Guid accountId)
        {
            var account = accountService.GetById(accountId);
            if (account == null)
            {
                throw new MyBankException(Response.InvalidAccount);
            }
            else
            {
                var user = userService.GetById(account.CustomerId);
                var transactions = transactionService.GetList(accountId);
                return new StatementDto
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Balance = account.Balance,
                    Transactions = transactions
                };
            }
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
    }
}
