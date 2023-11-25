using DataLayer.Entities.Products;
using EShooping.Application.DTOs.Orders;
using EShopping.Core.Entities.Ordering;
using EShopping.Core.Repositories;
using EShopping.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace EShopping.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly ICalculationRepository _calculationRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IGenericRepository<OrderDetailModel> _orderDetailRepository;

        public OrderController(ICalculationRepository calculationRepository, IProductRepository productRepository, IOrderRepository orderRepository, IGenericRepository<OrderDetailModel> orderDetailRepository)
        {
            _calculationRepository = calculationRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpPost("add-order")]
        public async Task<IActionResult> AddProductToOrder(OrderViewModel orderView)
        {

            int oldHeight=orderView.Height;
            int oldWidth = orderView.Width;

            //برای عرض و ارتفاع جدید

            int aa = orderView.Height % 10;
            if (aa != 0)
            {
                int b = 10 - aa;
                orderView.Height = orderView.Height + b;
            }
            else
            {
                orderView.Height = orderView.Height;
            }
            //=================

            int cc = orderView.Width % 10;
            if (cc != 0)
            {
                int d = 10 - cc;
                orderView.Width = orderView.Width + d;
            }
            else
            {
                orderView.Height = orderView.Height;
            }

            var detailRemove = await _orderRepository.GetOrderDetails();
            foreach (var item in detailRemove)
            {
                _orderDetailRepository.RemoveEntity(item);
            }

            decimal resultTotalCost = 0;
            decimal resultCost = 0;

            //محصول بیدا کردم
            var product = await _productRepository.GetProductByCategory(orderView.CategoryId, orderView.SubCategoryId);
            // فهمیدم فرمولاش چیه
            var calculation = await _calculationRepository.CalculationByProductId(product.Id);

            if (calculation != null)
            {
                foreach (var item in calculation)
                {
                    resultCost = 0;
                    #region پرده طلقی ایرانی
                    if (item.CalculationId == 1)
                    {
                        decimal a1 = 0;

                        decimal cost = await _calculationRepository.GetPriceById(1);
                        //resultCost = (((orderView.Height + 10) * orderView.Width) * cost) / 10000;
                        decimal a = orderView.Height + 10;
                        decimal b = a * orderView.Width;
                        decimal c = b * cost;
                        decimal d = c / 10000;
                        a1 = d;
                        resultCost = d;
                        
                    }
                    #endregion
                    #region پرده طلقی خارجی
                    else if (item.CalculationId == 2)
                    {
                        decimal cost = await _calculationRepository.GetPriceById(2);
                        resultCost = (((orderView.Height + 10) * orderView.Width) * cost) / 10000;
                    }
                    #endregion
                    #region پرده توری یک لایه
                    else if (item.CalculationId == 3)
                    {
                        decimal cost = await _calculationRepository.GetPriceById(3);
                        resultCost = (((orderView.Height + 10) * orderView.Width) * cost) / 10000;
                    }
                    #endregion
                    #region پرده توری دو لایه
                    else if (item.CalculationId == 4)
                    {

                        decimal result = 0;
                        decimal cost = await _calculationRepository.GetPriceById(4);
                        // resultCost =((((orderView.Height + 10) * 40) / 10000) * cost);

                        decimal a = orderView.Height + 10;
                        decimal b = a * 40;
                        decimal c = b / 10000;
                        decimal d = c * cost;
                        //جمع قیمت پرده توری + نصف گان
                        decimal e= (await _calculationRepository.GetGanPrice(orderView.Height) / 2);
                        decimal pp = 0;
                        pp = d +e;

                        resultCost += pp;
                        decimal cost1 = await _calculationRepository.GetPriceById(3);
                        resultCost += (((orderView.Height + 10) * orderView.Width) * cost1) / 10000;
                        resultCost += await _calculationRepository.GetZipper5Price(orderView.Width);
                        resultCost += await _calculationRepository.GetZipper2Price(orderView.Height);
                        resultCost += await _calculationRepository.GetChodonPrice(orderView.Width);
                        resultCost += await _calculationRepository.GetGanPrice(orderView.Height);
                        resultCost += await _calculationRepository.GetMagnetPrice(orderView.Height);
                        resultCost += await _calculationRepository.GetGlue4Price(orderView.Width);
                        resultCost += await _calculationRepository.GetGlue2Price(orderView.Height);
                        resultCost += await _calculationRepository.GetWagePrice(12);
                        resultCost += await _calculationRepository.GetWagePrice(13);
                    }
                    #endregion
                    #region زیپ چسب 5 سانت
                    else if (item.CalculationId == 5)
                    {
                        resultCost += await _calculationRepository.GetZipper5Price(orderView.Width);
                    }
                    #endregion
                    #region زیپ چسب 2.5 سانت
                    else if (item.CalculationId == 6)
                    {
                        resultCost += await _calculationRepository.GetZipper2Price(orderView.Height);
                    }
                    #endregion
                    #region جودون
                    else if (item.CalculationId == 7)
                    {
                        resultCost += await _calculationRepository.GetChodonPrice(orderView.Width);
                    }
                    #endregion
                    #region گان
                    else if (item.CalculationId == 8)
                    {
                        resultCost += await _calculationRepository.GetGanPrice(orderView.Height);
                    }
                    #endregion
                    #region آهنربا
                    else if (item.CalculationId == 9)
                    {
                        resultCost += await _calculationRepository.GetMagnetPrice(orderView.Height);
                    }
                    #endregion
                    #region چسب 2 طرفه 4 سانت
                    else if (item.CalculationId == 10)
                    {
                        resultCost += await _calculationRepository.GetGlue4Price(orderView.Width);
                    }
                    #endregion
                    #region چسب 2 طرفه 2 سانت
                    else if (item.CalculationId == 11)
                    {
                        resultCost += await _calculationRepository.GetGlue2Price(orderView.Height);
                    }
                    #endregion
                    #region اجرت دوخت
                    else if (item.CalculationId == 12)
                    {
                        resultCost += await _calculationRepository.GetWagePrice(12);
                    }
                    #endregion
                    #region اجرت بسته بندی
                    else if (item.CalculationId == 13)
                    {
                        resultCost += await _calculationRepository.GetPackagingPrice(13);
                    }
                    #endregion

                    var detail = new OrderDetailModel
                    {
                        OrderId = 0,
                        //ProductId= product.Id,
                        //CalculationId= item.CalculationId,
                        ProductSelectedCalculationId = item.Id,
                        Cost = resultCost,
                        TotalCost = resultCost * orderView.Count,
                    };
                    await _orderRepository.AddOrderDetail(detail);

                   
                    resultTotalCost += resultCost;
                }

                var order = new OrderModel
                {
                    ProductId = product.Id,
                    Height = oldHeight,
                    Width = oldWidth,
                    Count = orderView.Count,
                    Cost = resultTotalCost,
                    TotalCost = orderView.Count * resultTotalCost,
                };
                await _orderRepository.AddProductToOrder(order);

                var details = await _orderRepository.GetOrderDetails();

                details.ForEach(
                    c => c.OrderId = order.Id);
                foreach (var item in details)
                {
                    _orderDetailRepository.UpdateEntity(item);
                }
                await _orderDetailRepository.SaveChanges();
            }
            return Ok(resultTotalCost);
        }

        [HttpGet]
        [Route("get-all-orders")]

        public async Task<ActionResult<IList<ShowOrderViewModel>>> GetAll()
        {
            try
            {
                var query = await _orderRepository.GetAll();
                //_logger.LogInformation("All products retrieved");
                return Ok(query);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "An Exception has occured: {Exception}");
                throw;
            }

        }

            [HttpGet]
            [Route("GetOrderDetailsByOrderId/{orderId}")]
            public async Task<ActionResult<IList<ProductCategoryModel>>> GetOrderDetailsByOrderId(int orderId)
            {
                try
                {
                    var query = await _orderRepository.GetOrderDetailsByOrderId(orderId);
                    //_logger.LogInformation("All products retrieved");
                    return Ok(query);
                }
                catch (Exception e)
                {
                    //_logger.LogError(e, "An Exception has occured: {Exception}");
                    throw;
                }
            }
        }
    }

