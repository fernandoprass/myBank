using API.Models;
using API.Models.Dto;
using System;

namespace API.Contracts
{
    public interface IMyBankOrchestrator
    {
        /// <summary>Add an account</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns>A new Account object</returns>
        Account AddAccount(int customerId, double initialCredit);

        /// <summary>Get the account statement</summary>
        /// <param name="accountId">Customer identifier</param>
        /// <returns></returns>
        StatementDto GetStatement(Guid accountId);

    }
}
