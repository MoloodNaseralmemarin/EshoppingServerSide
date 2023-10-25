using EShopping.Core.Entities.Customers;
using EShopping.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly IGenericRepository<CustomerModel> _customerRepository;

        public CustomerRepository(IGenericRepository<CustomerModel> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task AddCustomer(CustomerModel customer)
        {
            await _customerRepository.AddEntity(customer);
            await _customerRepository.SaveChanges();
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }
    }
}
