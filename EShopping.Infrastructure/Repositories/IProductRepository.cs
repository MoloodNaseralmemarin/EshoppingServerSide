using DataLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Infrastructure.Repositories
{
    public interface IProductRepository: IDisposable
    {
        Task<ProductModel> GetProductByCategory(int categoryId, int subcategoryId);
    }
}
