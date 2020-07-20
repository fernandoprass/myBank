using API.Models;

namespace API.Contracts {
   /// <summary>The Customer domain contract</summary>
   public interface ICustomerRepository {

      /// <summary>Get a patient by Id</summary>
      /// <param name="id">The patient Id</param>
      Customer Get(int id);
   }
}
