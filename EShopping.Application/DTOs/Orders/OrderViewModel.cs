using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShooping.Application.DTOs.Orders
{
    public class OrderViewModel
    {
        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }
        public int Width { get; set; } 

        public int Height { get; set; } 

        public int Count { get; set; }
    }

    public class ShowOrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime CreateDate { get; set; }
        public string ProductName { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public int Count { get; set; }
        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class OrderDetailViewModel
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CalculationId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CalculationTitle{ get; set; }
        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }
    }
}

