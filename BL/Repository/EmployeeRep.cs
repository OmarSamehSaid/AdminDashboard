using AdminDash.BL.Interfaces;
using AdminDash.DAL.DataBase;
using AdminDash.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdminDash.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly ProjectDbContext DB;

        public EmployeeRep(ProjectDbContext DB)
        {
            this.DB = DB;
        }

        public void Add(Employee emp)
        {

            DB.Employee.Add(emp);
            DB.SaveChanges();
        }

        public IEnumerable<Employee> Search(string name)
        {
            var data = DB.Employee.Include("Department").Include("District").Where(a => a.Name.Contains(name)).Select(a=>a);
            return data;
        }
        public void Delete(int Id)
        {
            var OldData = DB.Employee.Find(Id);
            DB.Employee.Remove(OldData);
            DB.SaveChanges();
        }

        public IEnumerable<Employee> Get()
        {

            var Data = DB.Employee.Include("Department").Include("District");

            return Data;
        }

        public Employee GetById(int Id)
        {
            Employee data = GetEmployeeById(Id);
            return data;
        }

        public void Update(Employee emp)
        {
            DB.Entry(emp).State = EntityState.Modified;
            DB.SaveChanges();
        }



        #region refactor
        private Employee GetEmployeeById(int Id)
        {
            return DB.Employee.Include("Department").Include("District").Where(a => a.Id == Id).FirstOrDefault();
        }

        #endregion
    }
}
