using DataLayer.Entities.Products;
using EShooping.Application.DTOs.Orders;
using EShopping.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShopping.API.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        [HttpGet]
        [Route("GetAllProductCategories")]

        public async Task<ActionResult<IList<ProductCategoryModel>>> GetAll()
        {
            try
            {
                var query = await _productCategoryRepository.GetAll();
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
        [Route("GetProductCategory")]
        public async Task<ActionResult<IList<ProductCategoryModel>>> GetProductCategory()
        {
            try
            {
                var query = await _productCategoryRepository.GetProductCategory();
                return Ok(query);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("GetAllProductCategories/{parentId}")]

        public async Task<ActionResult<IList<OrderDetailViewModel>>> GetProductCategoryByParentId(int parentId)
        {
            try
            {
                var query = await _productCategoryRepository.GetProductCategoryByParentId(parentId);
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
