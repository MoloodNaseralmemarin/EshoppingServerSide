using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Entities.Ordering
{
    public class WageModel :BaseEntity
    {
        [Display(Name ="از ارتفاع")]
        public int Height1 { get; set; }
        [Display(Name = "تا ارتفاع")]
        public int Height2 { get; set; }
        [Display(Name = "ارتفاع محاسبه شده")]
        public int Height3 { get; set; }
        public int Price { get; set; }
    }
}
