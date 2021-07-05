using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AdminDash.DAL.Entities;

namespace AdminDash.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Department Name")]
        public String DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Enter Department Code")]
        public String DepartmentCode { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
