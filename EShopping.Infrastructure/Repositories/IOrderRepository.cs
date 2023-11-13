using DataLayer.Entities.Products;
using EShooping.Application.DTOs.Orders;
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
        Task<List<ShowOrderViewModel>> GetAll();

        Task AddProductToOrder(OrderModel orderModel);

        Task AddOrderDetail(OrderDetailModel orderDetailModel);

        Task UpdateOrderDetail(OrderDetailModel orderDetailModel);
        Task<List<OrderDetailModel>> GetOrderDetails();

        Task<List<OrderDetailViewModel>> GetOrderDetailsByOrderId(int orderId);
        

    }
}
