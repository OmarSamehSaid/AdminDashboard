using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminDash.DAL.Entities
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public String DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
