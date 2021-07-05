using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.Models
{
    public class RegistrationVM
    {
        [Required(ErrorMessage = "Enter Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password, ErrorMessage = "Enter Valid Password")]
        [MinLength(8, ErrorMessage = "min 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Doesn't Match")]
        public string ConfirmPassword { get; set; }
    }
}
