using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password, ErrorMessage = "Enter Valid Password")]
        [MinLength(8, ErrorMessage = "min 8")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
