using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.Models
{
    public class CountryVM
    {
        public int Id { get; set; }
        public String CountryName { get; set; }
        public ICollection<City> City { get; set; }
    }
}
