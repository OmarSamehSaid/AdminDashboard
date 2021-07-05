using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdminDash.DAL.Entities
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public String CityName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public ICollection<District> District { get; set; }
    }
}
