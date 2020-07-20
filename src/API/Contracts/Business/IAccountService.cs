using API.Models;
using API.Repository;
using System;

namespace API.Contracts
{
    /// <summary>The Account service contract</summary>
    public interface IAccountService
    {
        /// <summary>Add an account</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns>A new Account object</returns>
        Account Add(int customerId, double initialCredit);

        /// <summary>Update an account</summary>
        /// <param name="accountId">Account identifier</param>
        /// <param name="value">If the value is positive it is a deposit, if negative it is a withdrawal</param>
        /// <returns>The new account balance</returns>
        double UpdateBalance(Guid accountId, double value);
    }
}
