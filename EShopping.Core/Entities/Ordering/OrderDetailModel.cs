using DataLayer.Entities.Common;
using DataLayer.Entities.Products;
using EShopping.Core.Entities.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Entities.Ordering
{
    public class OrderDetailModel:BaseEntity
    {
        public int OrderId { get; set; }

        //public int ProductId { get; set; }

        //public int CalculationId { get; set; }

        public int ProductSelectedCalculationId { get; set; }
        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }


        public OrderModel Order { get; set; }


       // public ProductModel Product { get; set; }

       // public CalculationModel Calculation { get; set; }
        public ProductSelectedCalculationModel ProductSelectedCalculation { get; set; }
    }
}
