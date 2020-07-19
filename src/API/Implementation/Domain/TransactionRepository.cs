using API.Contracts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyBankContext dbContext;

        /// <summary>The AppointmentBusinessService class constructor</summary>
        /// <param name="dbContext"></param>
        public TransactionRepository(MyBankContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc />
        public Transaction Add(Guid accountId, double value)
        {
            Transaction transaction = new Transaction
            {
                Id = new Guid(),
                Date = DateTimeOffset.UtcNow,
                AccountId = accountId,
                Value = value
            };

            try
            {
                dbContext.Entry(transaction).State = EntityState.Added;
                dbContext.SaveChanges();
                return transaction;
            }
            catch
            {
                throw new Exception(Response.Failure.Message);
            }
        }

        /// <inheritdoc />
        public IEnumerable<TransactionListDto> List(Guid accountId)
        {
            return dbContext.Transaction.Where(x => x.Account.Id == accountId)
                                        .OrderBy(x => x.Date)
                                        .Select(x => new TransactionListDto(x.Customer.Name, x.Date, 0))
                                        .ToList();
        }
    }
}
