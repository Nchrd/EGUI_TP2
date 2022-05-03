using System.ComponentModel.DataAnnotations;

namespace lab2.Data.ViewModels
{
    public class LoginVm
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Username is required")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
