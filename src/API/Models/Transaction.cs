﻿using System;

namespace API.Models
{
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Value { get; set; }
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
