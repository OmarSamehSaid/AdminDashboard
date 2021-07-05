using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Interfaces
{
    public interface ICountryRep
    {
        IEnumerable<Country> Get();
        Country GetById(int Id);
    }
}
