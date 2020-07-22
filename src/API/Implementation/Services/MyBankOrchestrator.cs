using API.Contracts;
using API.Helpers;
using API.Models;
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
            var account = accountService.Add(customerId);
            if (!initialCredit.NearlyEqual(0))
            {
                transactionService.Add(account.Id, initialCredit);
            }

            return accountService.GetById(account.Id);
        }

        /// <inheritdoc />
        public StatementDto GetStatement(Guid accountId)
        {
            var account = accountService.GetById(accountId);
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
}
