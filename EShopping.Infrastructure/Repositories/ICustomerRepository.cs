using EShopping.Core.Entities.Customers;

namespace EShopping.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        Task AddCustomer(CustomerModel customer);
 
    }
}
