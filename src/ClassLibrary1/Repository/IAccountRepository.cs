using API.Models;
using System;

namespace API.Contracts
{
    /// <summary>The Acccount repository contract</summary>
    public interface IAccountRepository
    {
        /// <summary>Add an account</summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A new Account object</returns>
        Account Add(int customerId);

        /// <summary> Get an Account by identifier (Id) </summary>
        /// <param name="id">Account identifier</param>
        /// <returns>An exists account object</returns>
        Account GetById(Guid id);

        /// <summary>UpdateBalance an account</summary>
        /// <param name="id">Account identifier</param>
        /// <param name="balance">Balance value</param>
        /// <returns>True is the balance was updated</returns>
        bool UpdateBalance(Guid id, double balance);
    }
}

