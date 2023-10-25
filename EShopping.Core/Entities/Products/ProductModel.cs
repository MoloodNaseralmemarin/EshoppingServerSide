using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Products
{
    public class ProductModel:BaseEntity
    {

        #region properties
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public long ProductCategoryId { get; set; }
        public long SubProductCategoryId { get; set; }
        #endregion

        #region relations


        #endregion
    }


}
