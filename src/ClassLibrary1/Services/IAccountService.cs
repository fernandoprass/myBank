using API.Models;
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
        Account Add(int customerId);

        /// <summary> Get an Account by identifier (Id) </summary>
        /// <param name="id">Account identifier</param>
        /// <returns>An exists account object</returns>
        Account GetById(Guid id);

        /// <summary>UpdateBalance an account</summary>
        /// <param name="id">Account identifier</param>
        /// <param name="value">If the value is positive it is a deposit, if negative it is a withdrawal</param>
        /// <returns>The new account balance</returns>
        double UpdateBalance(Guid id, double value);
    }
}
