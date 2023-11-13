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
    public class ProductCategoryRepository : IProductCategoryRepository
    {

        #region constructor

        private readonly IGenericRepository<ProductCategoryModel> _productCategoryRepository;

        public ProductCategoryRepository(IGenericRepository<ProductCategoryModel> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }


        #endregion
        public async Task<List<ProductCategoryModel>> GetAll()
        {
            return await _productCategoryRepository.GetEntitiesQuery().ToListAsync();
        }
        public void Dispose()
        {
           _productCategoryRepository?.Dispose();
        }

        public async Task<List<ProductCategoryModel>> GetProductCategory()
        {
            return await _productCategoryRepository.GetEntitiesQuery()
               .Where(pc=>pc.ParentId==null).ToListAsync();
        }

        public async Task<List<ProductCategoryModel>> GetProductCategoryByParentId(long parentId)
        {
            return await _productCategoryRepository.GetEntitiesQuery()
                .Where(pc => pc.ParentId == parentId).ToListAsync();
        }
    }
}
