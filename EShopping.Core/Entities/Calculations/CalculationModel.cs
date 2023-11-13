﻿using DataLayer.Entities.Common;
using DataLayer.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Entities.Calculations
{
    public class CalculationModel:BaseEntity
    {
        public string Name { get; set; }
        public int PurchasePrice { get; set; }


        public ICollection<ProductSelectedCalculationModel> ProductSelectedCalculation { get; set; }


    }
}
