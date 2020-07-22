using API.Contracts;
using API.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Implementation
{
    /// <summary>The User Repository class</summary>
    public class UserRepository : IUserRepository
    {
        /// <summary> The user list is fixed </summary>
        private static List<User> GetUserList()
        {
            var users = new List<User>
            {
                new User {Id = 1, Name = "John", Surname = "Lennon"},
                new User {Id = 2, Name = "Paul", Surname = "McCartney"},
                new User {Id = 3, Name = "George", Surname = "Harrison"},
                new User {Id = 4, Name = "Ringo", Surname = "Starr"},
                new User {Id = 5, Name = "Mick", Surname = "Jagger"},
                new User {Id = 6, Name = "Keith", Surname = "Richards"},
                new User {Id = 7, Name = "Charlie", Surname = "Watts"},
                new User {Id = 8, Name = "Ronnie", Surname = "Wood"},
            };
            return users;
        }

        /// <inheritdoc />
        public User GetById(int id)
        {
            return GetUserList().FirstOrDefault(x => x.Id == id);
        }
    }
}
