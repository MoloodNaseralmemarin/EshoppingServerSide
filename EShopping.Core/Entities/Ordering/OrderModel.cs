using DataLayer.Entities.Common;
using DataLayer.Entities.Products;

namespace EShopping.Core.Entities.Ordering
{
    public class OrderModel:BaseEntity
    {
        public int ProductId { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public int Count { get; set; }
        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }

        public ProductModel Product { get; set; }

        public ICollection<OrderDetailModel> OrderDetails { get; set; }


    }
}
