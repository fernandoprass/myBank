﻿using System;
using System.Collections.Generic;
using API.Models;

namespace API.Contracts
{
    /// <summary>The transaction service contract </summary>
    public interface ITransactionService
    {
        /// <summary>Add an new transaction</summary>
        /// <param name="accountId">Customer identifier</param>
        /// <param name="value">If the value is positive it is a deposit, if negative it is a withdrawal</param>
        /// <returns>the result of the operation</returns>
        Transaction Add(Guid accountId, double value);

        /// <summary> Return the transactions list </summary>
        /// <param name="accountId">Account identifier</param>
        /// <returns>A list of transactions</returns>
        IEnumerable<TransactionDto> GetList(Guid accountId);
    }
}
