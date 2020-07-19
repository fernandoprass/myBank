using API.Contracts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyBankContext dbContext;

        public AccountRepository(MyBankContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc />
        public Account Add(int customerId, double initialCredit)
        {
            Account account = new Account
            {
                Id = new Guid(),
                CreationDate = DateTimeOffset.UtcNow,
                CostumerId = customerId,
                Balance = initialCredit
            };

            try
            {
                dbContext.Entry(account).State = EntityState.Added;
                dbContext.SaveChanges();
                return account;
            }
            catch 
            {
                throw new Exception(Response.Failure.Message);
            }
        }
    }
}
