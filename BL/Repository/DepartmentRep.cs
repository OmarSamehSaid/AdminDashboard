using AdminDash.BL.Interfaces;
using AdminDash.DAL.DataBase;
using AdminDash.DAL.Entities;
using AdminDash.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly ProjectDbContext DB;

        public DepartmentRep(ProjectDbContext DB)
        {
            this.DB = DB;
        }

        public void Add(Department Dep)
        {

            DB.Department.Add(Dep);
            DB.SaveChanges();
        }

        public void Delete(int Id)
        {
            var OldData = DB.Department.Find(Id);
            DB.Department.Remove(OldData);
            DB.SaveChanges();
        }

        public IEnumerable<Department> Get()
        {
            //var Data=DB.Department.Select(a=>new DepartmentVM
            //{   Id=a.Id,
            //    DepartmentName=a.DepartmentName,
            //    DepartmentCode=a.DepartmentCode
            //});
            var Data = DB.Department.Select(a => a);

            return Data;
        }

        public Department GetById(int Id)
        {
            //var data = DB.Department.Where(a => a.Id == Id).Select(a => new DepartmentVM {
            //    Id = a.Id,
            //    DepartmentName = a.DepartmentName,
            //    DepartmentCode = a.DepartmentCode
            //}).First();
            var data = DB.Department.Where(a => a.Id == Id).FirstOrDefault();
            return data;
        }
        public void Update(Department Dep)
        {
            DB.Entry(Dep).State = EntityState.Modified;
            DB.SaveChanges();
        }
   
    }
}
