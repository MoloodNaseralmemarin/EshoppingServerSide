using DataLayer.Entities.Common;
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
    public class ProductCategoryModel:BaseEntity
    {
        #region
        #endregion
        #region properties
        [Display(Name="نام")]
        public string Name { get; set; }
        
        public int? ParentId { get; set; }
        #endregion
        #region relations
        public ICollection<ProductModel> Products { get; set; }
        #endregion 


    }
}
