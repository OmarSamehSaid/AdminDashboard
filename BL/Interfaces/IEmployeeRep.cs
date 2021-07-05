using AdminDash.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Interfaces
{
    public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();
        public IEnumerable<Employee> Search(string name);
        Employee GetById(int Id);
        void Add(Employee emp);
        void Update(Employee emp);
        void Delete(int Id);


    }
}
