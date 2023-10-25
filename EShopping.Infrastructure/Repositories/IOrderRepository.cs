using EShopping.Core.Entities.Ordering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        Task AddProductToOrder(OrderModel orderModel);
    }
}
