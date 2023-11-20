using EShopping.Core.Entities.Customers;
using EShopping.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EShopping.API.Controllers
{

    public class CustomerController : ApiController
    {

        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpPost]
        [Route("add-customer")]
        public async Task<IActionResult> AddCustomer(CustomerModel customerModel)
        {

            await _customerRepository.AddCustomer(customerModel);
            return Ok();
        }
    }
}
