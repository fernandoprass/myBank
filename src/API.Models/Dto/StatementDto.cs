using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using API.Contracts;

namespace API.Models.Dto
{
    public class StatementDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public double Balance { get; set; }

        [DataMember]
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}
