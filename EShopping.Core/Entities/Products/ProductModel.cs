using DataLayer.Entities.Common;
using EShopping.Core.Entities.Calculations;
using EShopping.Core.Entities.Ordering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Products
{
    public class ProductModel:BaseEntity
    {

        #region properties

        [Display(Name ="نام محصول")]
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public int SubProductCategoryId { get; set; }
        #endregion

        #region relations

        public OrderModel Order { get; set; }

        public ProductCategoryModel ProductCategory { get; set; }

        public ICollection<ProductSelectedCalculationModel> ProductSelectedCalculation { get; set; }

        //public ICollection<ProductModel> Products { get; set; }

        //public ICollection<CalculationModel> Calculations { get; set; }

        #endregion
    }


}
