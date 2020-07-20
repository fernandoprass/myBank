using System;
using System.Collections.Generic;

namespace API.Models {
    public partial class Account
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public double Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
