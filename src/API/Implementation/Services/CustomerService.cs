using API.Contracts;
using API.Contracts.Business;
using API.Models;

namespace API.Implementation.Business
{
    public class CustomerService : ICustomerService {
      private readonly ICustomerRepository customerRepository;

      /// <summary>The AppointmentBusinessService class constructor</summary>
      /// <param name="appointmentDomainService"></param>
      public CustomerService(ICustomerRepository customerRepository) {
         this.customerRepository = customerRepository;
      }

      /// <inheritdoc />
      public Customer Get(int id) {
         return customerRepository.Get(id);
      }
   }
}
