using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Interfaces
{
    public interface ICityRep
    {
        IEnumerable<City> Get();
        City GetById(int Id);
        IEnumerable<City> GetCityByCountry(int CountryId);

    }
}
