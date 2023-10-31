using DataLayer.Entities.Common;
using EShopping.Core.Entities.Ordering;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Users
{
    public class UserModel :BaseEntity
    {
        [Display(Name ="نام")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "شماره همراه")]
        [Required]
        public string CellPhone { get; set; }

        [Display(Name = "تفن ثابت")]
        [Required]
        public string TelPhone { get; set; }


    }
}
