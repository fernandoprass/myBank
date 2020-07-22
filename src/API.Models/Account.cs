using System;
using System.Collections.Generic;

namespace API.Models {
    /// <summary> The account data access object </summary>
    public partial class Account
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public double Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
