using API.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        /// <summary>
        /// The AppointmentController constructor
        /// </summary>
        /// <param name="appointmentRepository"></param>
        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        // GET: api/Transactions
        /// <summary> Return the transactions </summary>
        /// <param name="accountId">Account identifier</param>
        /// <returns>A list of transactions</returns>
        [HttpGet("List")]
        public IActionResult List(Guid accountId)
        {
            var transaction = transactionService.List(accountId);
            return new OkObjectResult(transaction);
        }

        /// <summary> Add a new account </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns>The result of the operation</returns>
        [HttpPost("Add")]
        public Transaction Add([FromQuery] Guid accountId, double value)
        {

            var transaction = transactionService.Add(accountId, value);
            return transaction;
        }
    }
}
