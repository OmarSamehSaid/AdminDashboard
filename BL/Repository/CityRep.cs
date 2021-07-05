using AdminDash.BL.Interfaces;
using AdminDash.DAL.DataBase;
using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly ProjectDbContext DB;

        public CityRep(ProjectDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<City> Get()
        {
            var data = DB.City.Select(a => a);
            return data;
        }

        public City GetById(int Id)
        {
            var data = DB.City.Where(a => a.Id == Id).FirstOrDefault();
            return data;
        }

        public IEnumerable<City> GetCityByCountry(int CountryId)
        {
            var data = DB.City.Where(a => a.CountryId == CountryId).Select(a=>a);
            return data;
        }
    }
}
