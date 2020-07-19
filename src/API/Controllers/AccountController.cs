using API.Contracts;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        /// <summary> The account service constructor </summary>
        /// <param name="accountService"></param>
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
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
                var account = accountService.Add(customerId, initialCredit);
                scope.Complete();
                return account;
            }
        }
    }
}
