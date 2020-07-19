using System;
using System.Collections.Generic;

namespace API.Models {
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public double Balance { get; set; }
        public int CostumerId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
