using DataLayer.Entities.Products;
using EShooping.Application.DTOs.Orders;
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

        public async Task<List<ShowOrderViewModel>> GetAll()
        {
            return await _orderRepository.GetEntitiesQuery()
                .Include(o=>o.Product)
                .OrderByDescending(o=>o.Id)
                .Select(o=>new ShowOrderViewModel
                {
                   Cost = o.Cost,
                   Count = o.Count,
                   CreateDate = DateTime.Now,
                   Height = o.Height,
                   ProductName = o.Product.ProductName,
                   OrderId=o.Id,
                   TotalCost = o.TotalCost,
                   Width=o.Width,
                })
                .ToListAsync();
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

        public async Task<List<OrderDetailModel>> GetOrderDetails()
        {
            return await _orderDetailRepository.GetEntitiesQuery()
                .Where(o=>o.OrderId==0)
                .ToListAsync();
        }
        public async Task UpdateOrderDetail(OrderDetailModel orderDetailModel)
        {
           _orderDetailRepository.UpdateEntity(orderDetailModel);
            await _orderDetailRepository.SaveChanges();
        }

        public async Task<List<OrderDetailViewModel>> GetOrderDetailsByOrderId(int orderId)
        {
            //            return await _orderDetailRepository.GetEntitiesQuery().
            //            Where(od => od.OrderId == orderId)
            //.OrderBy(od => od.Id)
            //.ThenBy(od => od.ProductSelectedCalculation.Calculation.Id)
            //.ThenBy(od => od.Cost)
            //.Select(o => new OrderDetailViewModel
            //{
            //    Id = o.Id,
            //    OrderId = orderId,
            //    CalculationId = o.ProductSelectedCalculation.Calculation.Id,
            //    CreateDate = o.CreateDate,
            //    CalculationTitle = o.ProductSelectedCalculation.Calculation.Name,
            //    Cost = o.Cost,
            //    TotalCost = o.TotalCost,
            //})
            //.ToListAsync();
            //        }
            //    }


            var query= await _orderDetailRepository.GetEntitiesQuery()
                .Where(o=>o.OrderId==orderId)
                .OrderBy(p => p.Id)
                .Select(o => new OrderDetailViewModel
                {
                    Id = o.Id,
                    OrderId = orderId,
                    CalculationId =o.ProductSelectedCalculationId ,
                    CalculationTitle =o.ProductSelectedCalculation.Calculation.Name,
                    
                    Cost=o.Cost,
                    TotalCost=o.TotalCost,
                      })
                     .ToListAsync();

            return query;

                }

        

    public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}
