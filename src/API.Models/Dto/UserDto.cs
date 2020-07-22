using System.Runtime.Serialization;

namespace API.Models.Dto
{
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }
    }
}
