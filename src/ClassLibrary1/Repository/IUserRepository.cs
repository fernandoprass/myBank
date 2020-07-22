using API.Models;

namespace API.Contracts {
    /// <summary>The User Repository class</summary>
    public interface IUserRepository {

        /// <summary> Get an User by identifier (Id) </summary>
        /// <param name="id">The patient Id</param>
        User GetById(int id);
   }
}
