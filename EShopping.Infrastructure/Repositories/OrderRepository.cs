using DataLayer.Entities.Products;
using EShopping.Core.Entities.Ordering;
using EShopping.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<OrderDetailModel> _orderDetailRepository;
        public OrderRepository(IGenericRepository<OrderModel> orderRepository, IGenericRepository<OrderDetailModel> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task AddProductToOrder(OrderModel orderModel)
        {
            await _orderRepository.AddEntity(orderModel);
            await _orderRepository.SaveChanges();

        }

        public async Task AddOrderDetail(OrderDetailModel orderDetailModel)
        {
            await _orderDetailRepository.AddEntity(orderDetailModel);
            await _orderDetailRepository.SaveChanges();
        }
        public async Task<List<OrderModel>> GetOrder()
        {
            var u = await _orderRepository.GetAll()
                  .Where(o=>!o.IsDelete)
                  .ToListAsync();
            return u;

        }
        public void Dispose()
        {
            _orderRepository.Dispose();
        }


    }
}
