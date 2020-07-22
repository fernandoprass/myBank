using API.Models;
using API.Models.Dto;

namespace API.Contracts
{
    /// <summary>The User Service class contract</summary>
    public interface IUserService {
        /// <summary> Get an User by identifier (Id) </summary>
        /// <param name="id">The patient Id</param>
        User GetById(int id);
    }
}
