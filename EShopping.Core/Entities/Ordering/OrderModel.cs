using DataLayer.Entities.Common;
using DataLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Entities.Ordering
{
    public class OrderModel:BaseEntity
    {
        public int UserId { get; set; }
        public int ProductCategoryId { get; set; }

        public int SubProductCategoryId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Count { get; set; }
        public int Magnet { get; set; }
    }
}
