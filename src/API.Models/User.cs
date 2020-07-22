using System;
using System.Collections.Generic;

namespace API.Models {
    /// <summary> The user data access object </summary>
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
