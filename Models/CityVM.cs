using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AdminDash.Models
{
    public class CityVM
    {
        public int Id { get; set; }
        public String CityName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<District> District { get; set; }
    }
}
