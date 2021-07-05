using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Interfaces
{
    public interface IDistrictRep
    {
        IEnumerable<District> Get();
        District GetById(int Id);
        IEnumerable<District> GetDistrictByCity(int CityID);
    }
}
