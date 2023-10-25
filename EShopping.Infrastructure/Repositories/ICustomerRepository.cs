using EShopping.Core.Entities.Customers;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        Task AddCustomer(CustomerModel customer);
 
    }
}
