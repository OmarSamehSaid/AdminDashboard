using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.Models
{
    public class DistrictVM
    {
        public int Id { get; set; }
        public String DistrictName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
