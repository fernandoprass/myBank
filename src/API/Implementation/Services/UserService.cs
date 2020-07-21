using API.Contracts;
using API.Contracts.Business;
using API.Models;

namespace API.Implementation.Business
{
    /// <summary>The Customer Service class</summary>
    public class UserService : ICustomerService {
      private readonly IUserRepository _userRepository;

      /// <summary>The AppointmentBusinessService class constructor</summary>
      /// <param name="appointmentDomainService"></param>
      public UserService(IUserRepository userRepository) {
         this._userRepository = userRepository;
      }

      /// <inheritdoc />
      public User Get(int id) {
         return _userRepository.Get(id);
      }
   }
}
