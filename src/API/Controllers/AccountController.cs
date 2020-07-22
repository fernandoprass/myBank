using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Transactions;
using API.Models.Dto;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMyBankOrchestrator myBankOrchestrator;

        /// <summary> The account service constructor </summary>
        /// <param name="myBankOrchestrator"></param>
        public AccountController(IMyBankOrchestrator myBankOrchestrator)
        {
            this.myBankOrchestrator = myBankOrchestrator;
        }

        /// <summary> Add a new account </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns>The result of the operation</returns>
        [HttpPost("Add")]
        public Account Add([FromQuery] int customerId, double initialCredit)
        {
            using (var scope = new TransactionScope())
            {
                var account = myBankOrchestrator.AddAccount(customerId, initialCredit);
                scope.Complete();
                return account;
            }
        }

        /// <summary> Add a new account </summary>
        /// <param name="accountId">Customer identifier</param>
        /// <returns>The result of the operation</returns>
        [HttpPost("GetStatement")]
        public StatementDto GetStatement([FromQuery] Guid accountId)
        {
            var statement = myBankOrchestrator.GetStatement(accountId);
            return statement;
        }
    }
}
