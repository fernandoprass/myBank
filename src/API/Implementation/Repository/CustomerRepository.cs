using API.Contracts;
using API.Models;
using System.Linq;

namespace API.Repository {
   /// <summary>The Customer domain class</summary>
   public class CustomerRepository : ICustomerRepository {
      private readonly MyBankContext _dbContext;

      /// <summary>The class constructor</summary>
      /// <param name="dbContext">The database context</param>
      public CustomerRepository(MyBankContext dbContext) {
         _dbContext = dbContext;
      }

      /// <inheritdoc />
      public Customer Get(int id) {
         return _dbContext.Patient.Where(x => x.Id == id).SingleOrDefault();
      }
   }
}
