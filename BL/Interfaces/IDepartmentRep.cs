using AdminDash.DAL.Entities;
using AdminDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Interfaces
{
    public interface IDepartmentRep
    {
        IEnumerable<Department> Get();
        Department GetById(int Id);
        void Add(Department Dep);
        void Update(Department Dep);
        void Delete (int Id);

    }
}
