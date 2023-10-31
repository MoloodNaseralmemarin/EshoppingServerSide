using DataLayer.Entities.Products;
using EShopping.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<ProductModel> _productRepository;

        public ProductRepository(IGenericRepository<ProductModel> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductModel> GetProductByCategory(int categoryId, int subcategoryId)
        {
                var order = await _productRepository.GetAll()
                    .SingleOrDefaultAsync(p => p.ProductCategoryId == categoryId && p.SubProductCategoryId==subcategoryId);
                return order;
        }
                
                
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
