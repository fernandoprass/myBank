using API.Models;
using System;

namespace API.Contracts
{
    /// <summary>The Acccount repository contract</summary>
    public interface IAccountRepository
    {
        /// <summary>Add an account</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="initialCredit">Initial credit</param>
        /// <returns>A new Account object</returns>
        Account Add(int customerId, double initialCredit);

        /// <summary> Get an Account by identifier (Id) </summary>
        /// <param name="id">Account identifier</param>
        /// <returns>An exists account object</returns>
        Account GetById(Guid id);

        /// <summary>Update an account</summary>
        /// <param name="account">Account object</param>
        /// <returns>The new account object</returns>
        Account Update(Account account);
    }
}

