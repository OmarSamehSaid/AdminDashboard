using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminDash.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public String CountryName { get; set; }
        public ICollection<City> City { get; set; }
    }
}
