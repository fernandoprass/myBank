using API.Models;

namespace API.Contracts {
    /// <summary>The User Repository contract</summary>
    public interface IUserRepository {

        /// <summary> Get an User by identifier (Id) </summary>
        /// <param name="id">The patient Id</param>
        User GetById(int id);
   }
}
