using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contracts.Business {
   /// <summary>The Customer business implementation</summary>
   public interface ICustomerService {
      /// <summary>Get a patient by Id</summary>
      /// <param name="id">The patient Id</param>
      User Get(int id);
   }
}
