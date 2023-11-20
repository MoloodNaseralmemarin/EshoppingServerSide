
using System.ComponentModel.DataAnnotations;

namespace EShooping.Application.DTOs.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "نام")]
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

    public enum RegisterUserResult
    {
        Success,
        EmailExists,
        UserNameExists
    }

    public class LoginUserViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }

    public enum LoginUserResult
    {
        Success,
        IncorrectData,
        NotActivated,
        NotAdmin
    }
}
