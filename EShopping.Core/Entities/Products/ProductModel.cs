using DataLayer.Entities.Common;
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

        public ProductCategoryModel ProductCategory { get; set; }

        #endregion
    }


}
