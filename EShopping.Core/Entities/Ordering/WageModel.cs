using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Entities.Ordering
{
    public class WageModel :BaseEntity
    {
        public int Widht { get; set; }
        public int Height { get; set; }
        public int price { get; set; }
    }
}
