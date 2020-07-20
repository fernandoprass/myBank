using System;

namespace API.Contracts
{
    public class TransactionDto {
      public DateTimeOffset Date { get; set; }
      public double Value { get; set; }

        public TransactionDto(DateTimeOffset date, double value) {
         Date = date;
         Value = value;
        }
   }
}
