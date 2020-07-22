using System;
using System.Runtime.Serialization;

namespace API.Models.Dto
{
    public class AccountDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTimeOffset CreationDate { get; set; }

        [DataMember]
        public double Balance { get; set; }

        [DataMember]
        public int CustomerId { get; set; }
    }
}
