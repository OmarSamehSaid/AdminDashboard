using AdminDash.DAL.Entities;
using AdminDash.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();
        }
    }
}
