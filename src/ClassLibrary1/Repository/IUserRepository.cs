using API.Models;

namespace API.Contracts {
   /// <summary>The Customer domain contract</summary>
   public interface IUserRepository {

      /// <summary>Get a patient by Id</summary>
      /// <param name="id">The patient Id</param>
      User Get(int id);
   }
}
