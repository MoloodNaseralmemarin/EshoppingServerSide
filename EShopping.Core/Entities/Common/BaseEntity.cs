using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string? Description { get; set; }

        public bool IsDelete { get; set; }


        //[Required(ErrorMessage =ErrorMessage.RequiredMessage)]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        [DataType(DataType.Date)]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}
