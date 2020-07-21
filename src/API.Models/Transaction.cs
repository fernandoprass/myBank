using System;

namespace API.Models
{
    /// <summary> The transcation data access object </summary>
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Value { get; set; }
        public Guid AccountId { get; set; }
    }
}
