using API.Contracts;
using API.Contracts.Business;
using API.Models;

namespace API.Implementation.Business
{
    public class CustomerService : ICustomerService {
      private readonly ICustomerRepository patientDomainService;

      /// <summary>The AppointmentBusinessService class constructor</summary>
      /// <param name="appointmentDomainService"></param>
      public CustomerService(ICustomerRepository patientDomainService) {
         this.patientDomainService = patientDomainService;
      }

      /// <inheritdoc />
      public Customer Get(int id) {
         return patientDomainService.Get(id);
      }
   }
}
