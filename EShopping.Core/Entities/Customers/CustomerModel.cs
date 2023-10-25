using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopping.Core.Entities.Customers
{
    public class CustomerModel:BaseEntity
    {

        public CustomerModel()
        {
           
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CooperationPercentage { get; set; }
    }
}
