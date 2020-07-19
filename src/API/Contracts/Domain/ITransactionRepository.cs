using API.Models;
using System;
using System.Collections.Generic;

namespace API.Contracts
{
    /// <summary>The Account repository contract</summary>
    public interface ITransactionRepository
    {
        /// <summary>Add an new transaction</summary>
        /// <param name="accountId">Customer identifier</param>
        /// <param name="value">If the value is positive it is a deposit, if negative it is a withdrawal</param>
        /// <returns>the result of the operation</returns>
        Transaction Add(Guid accountId, double value);

        /// <summary> Return the transactions </summary>
        /// <param name="accountId">Account identifier</param>
        /// <returns>A list of transactions</returns>
        IEnumerable<TransactionListDto> List(Guid accountId);
    }
}