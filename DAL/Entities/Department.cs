using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminDash.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public String DepartmentName { get; set; }
        [StringLength(50)]
        public String DepartmentCode { get; set; }

        public ICollection <Employee> Employee { get; set; }
    }

}
