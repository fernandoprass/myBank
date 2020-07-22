using API.Contracts;
using API.Models;

namespace API.Implementation
{
    /// <summary>The User Service class</summary>
    public class UserService : IUserService {
      private readonly IUserRepository userRepository;

        /// <summary>The User Service class constructor</summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository) {
         this.userRepository = userRepository;
      }

      /// <inheritdoc />
      public User GetById(int id)
      {
         return userRepository.GetById(id);
      }
   }
}
