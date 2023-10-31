using DataLayer.Entities.Common;
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

        public int ProductSelectedCalculationId { get; set; }
        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }
    }
}
