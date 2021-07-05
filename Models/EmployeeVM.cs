using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AdminDash.DAL.Entities;
using Microsoft.AspNetCore.Http;
namespace AdminDash.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(50, ErrorMessage = "Max len 50")]
        [MinLength(3, ErrorMessage = "Min len 3")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Please Enter Salary")]
        [Range(2000,10000, ErrorMessage = "Range 2000 ~ 10000")]
        public float Salary { get; set; }
        [Required(ErrorMessage = "Please Enter Hire Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Enter valid date")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter valid Email")]
        public String Email { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Please Choose a Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Choose a District")]
        public int DistrictId { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public IFormFile CvUrl { get; set; }
        public Department Department { get; set; }
        public District District { get; set; }
    }
}
