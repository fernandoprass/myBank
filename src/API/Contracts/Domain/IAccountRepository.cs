using API.Models;
using API.Repository;
using System;

namespace API.Contracts
{
    /// <summary>The Acccount repository contract</summary>
    public interface IAccountRepository
    {
        /// <summary>Add an account</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns>A new object Account</returns>
        Account Add(int customerId, double initialCredit);
    }
}

