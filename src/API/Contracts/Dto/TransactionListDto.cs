using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contracts {
   public class TransactionListDto {
      public string Description { get; set; }
      public DateTimeOffset Date { get; set; }
      public double Value { get; set; }

        public TransactionListDto(string description, DateTimeOffset date, double value) {
         Description = description;
         Date = date;
         Value = value;
        }
   }
}
