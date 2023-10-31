using DataLayer.Entities.Common;

namespace EShopping.Core.Entities.Ordering
{
    public class OrderModel:BaseEntity
    {
        public int ProductId { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public int Count { get; set; }
        public int Cost { get; set; }
        public int TotalCost { get; set; }

    }
}
