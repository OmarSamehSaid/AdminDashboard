using AdminDash.BL.Interfaces;
using AdminDash.DAL.DataBase;
using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Repository
{
    public class DistrictRep : IDistrictRep
    {
        private readonly ProjectDbContext DB;

        public DistrictRep(ProjectDbContext DB)
        {
            this.DB = DB;
        }
        public IEnumerable<District> Get()
        {
            var data = DB.District.Select(a => a);
            return data;
        }

        public District GetById(int Id)
        {
            var data = DB.District.Where(a => a.Id == Id).FirstOrDefault();
            return data;
        }

        public IEnumerable<District> GetDistrictByCity(int CityID)
        {
            var data = DB.District.Where(a => a.CityId == CityID).Select(a=>a);
            return data;
        }
    }
}
