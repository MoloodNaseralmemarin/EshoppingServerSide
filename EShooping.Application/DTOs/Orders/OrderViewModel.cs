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
}
