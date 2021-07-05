using AdminDash.BL.Interfaces;
using AdminDash.DAL.DataBase;
using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Repository
{
    public class CountryRep : ICountryRep
    {
        private readonly ProjectDbContext DB;

        public CountryRep(ProjectDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<Country> Get()
        {
            var data = DB.Country.Select(a => a);
            return data;
        }

        public Country GetById(int Id)
        {
            var data = DB.Country.Where(a => a.Id == Id).FirstOrDefault();
            return data;
        }
    }
}
