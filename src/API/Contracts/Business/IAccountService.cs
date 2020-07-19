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
        /// <returns>A new object Account</returns>
        Account Add(int customerId, double initialCredit);
    }
}
