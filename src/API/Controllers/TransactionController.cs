using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet("Get")]
        public IActionResult List(Guid accountId)
        {
            var transaction = transactionService.List(accountId);
            return new OkObjectResult(transaction);
        }
    }
}
