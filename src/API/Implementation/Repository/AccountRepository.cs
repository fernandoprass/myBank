using API.Contracts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        //private readonly MyBankContext dbContext;

        //public AccountRepository(MyBankContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}


        /// <inheritdoc />
        public Account GetById(Guid id)
        {
            //return dbContext.Account.FirstOrDefault(x => x.Id == id);
            return null;
        }


        /// <inheritdoc />
        public Account Add(int customerId, double initialCredit)
        {
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTimeOffset.UtcNow,
                CustomerId = customerId,
                Balance = initialCredit
            };

            try
            {
                //dbContext.Entry(account).State = EntityState.Added;
                //dbContext.SaveChanges();
                return account;
            }
            catch 
            {
                throw new Exception(Response.Failure.Message);
            }
        }

        /// <inheritdoc />
        public Account Update(Account account)
        {
            try
            {
                //dbContext.Entry(account).State = EntityState.Modified;
                //dbContext.SaveChanges();
                return account;
            }
            catch
            {
                throw new Exception(Response.Failure.Message);
            }
        }
    }
}
