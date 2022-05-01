using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab2.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "You must provide an username.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must have between 6 and 20 characters.")]
        [Required(ErrorMessage = "You must provide a password.")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "You must confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password must match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "You must provide a mail.")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Display(Name = "Confirm  mail")]
        [Required(ErrorMessage = "You must confirm your mail.")]
        [Compare("Mail", ErrorMessage = "The mail and confirmation mail must match.")]
        [DataType(DataType.EmailAddress)]
        public string ConfirmMail { get; set; }
    }
}
