using DataLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public interface IProductCategoryRepository: IDisposable
    {
        Task<List<ProductCategoryModel>> GetAll();

        Task<List<ProductCategoryModel>> GetProductCategory();

        Task<List<ProductCategoryModel>> GetProductCategoryByParentId(long parentId);
    }
}
