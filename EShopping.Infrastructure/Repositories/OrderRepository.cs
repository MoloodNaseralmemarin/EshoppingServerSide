using DataLayer.Entities.Products;
using EShopping.Core.Entities.Ordering;
using EShopping.Core.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IGenericRepository<OrderModel> _orderRepository;

        public OrderRepository(IGenericRepository<OrderModel> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddProductToOrder(OrderModel orderModel)
        {
            await _orderRepository.AddEntity(orderModel);
            await _orderRepository.SaveChanges();
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}
