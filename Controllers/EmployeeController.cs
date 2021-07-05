using AdminDash.BL.Interfaces;
using AdminDash.DAL.Entities;
using AdminDash.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using AdminDash.BL.Helper;

namespace AdminDash.Controllers
{
    public class EmployeeController : Controller
    {

        #region Prop
        private readonly IEmployeeRep EmployeeRep;
        private readonly ICountryRep CountryRep;
        private readonly ICityRep CityRep;
        private readonly IDistrictRep DistrictRep;
        private readonly IDepartmentRep DepartmentRep;
        private readonly IMapper mapper;

        #endregion

        #region Constructor
        public EmployeeController(IDepartmentRep DepartmentRp, IEmployeeRep EmployeeRep, ICountryRep CountryRep, ICityRep CityRep, IDistrictRep DistrictRep, IMapper mapper)
        {
            this.DepartmentRep = DepartmentRp;
            this.EmployeeRep = EmployeeRep;
            this.CountryRep = CountryRep;
            this.CityRep = CityRep;
            this.DistrictRep = DistrictRep;
            this.mapper = mapper;
           
        }
        #endregion

        #region Action

        public IActionResult Index(string Name="")
        {
            if (Name == ""|| Name== null) { 
            var data = mapper.Map<IEnumerable<EmployeeVM>>(EmployeeRep.Get());
            return View(data);
            }
            else
            {
                var data = mapper.Map<IEnumerable<EmployeeVM>>(EmployeeRep.Search(Name));
                return View(data);
            }
        }
        public IActionResult Details(int Id)
        {
            var empData = EmployeeRep.GetById(Id);
            var data = mapper.Map<EmployeeVM>(empData);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var DepData = DepartmentRep.Get();
            var CountryData = CountryRep.Get();

            var modeldata = mapper.Map<IEnumerable<DepartmentVM>>(DepData);
            var CountryModeldata = mapper.Map<IEnumerable<CountryVM>>(CountryData);

            ViewBag.DepartmentList = new SelectList(modeldata, "Id", "DepartmentName");
            ViewBag.CountryList = new SelectList(CountryModeldata, "Id", "CountryName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = mapper.Map<Employee>(model);
                    string FileName = FilesHelper.Upload(model.PhotoUrl,"Photos");
                    string FileNameCv = FilesHelper.Upload(model.CvUrl, "Docs");
                    data.PhotoName = FileName;
                    data.CvName = FileNameCv;
                    EmployeeRep.Add(data);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                var DepData = DepartmentRep.Get();
                var CountryData = CountryRep.Get();

                var modeldata = mapper.Map<IEnumerable<DepartmentVM>>(DepData);
                var CountryModeldata = mapper.Map<IEnumerable<CountryVM>>(CountryData);

                ViewBag.DepartmentList = new SelectList(modeldata, "Id", "DepartmentName");
                ViewBag.CountryList = new SelectList(CountryModeldata, "Id", "CountryName");
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var empData = EmployeeRep.GetById(Id);
            var dataVM = mapper.Map<EmployeeVM>(empData);


            var empcitytData = CityRep.GetById(dataVM.District.CityId);
            var empcountrytData = CountryRep.GetById(empcitytData.CountryId);

            var DepData = DepartmentRep.Get();
            var CountryData = CountryRep.Get();
            var CityData = CityRep.GetCityByCountry(empcountrytData.Id);
            var DistrictData = DistrictRep.GetDistrictByCity(empcitytData.Id);



            ViewBag.DepartmentList = new SelectList(DepData, "Id", "DepartmentName", dataVM.DepartmentId);
            ViewBag.CountryList = new SelectList(CountryData, "Id", "CountryName", empcountrytData.Id);


            ViewBag.CityList = new SelectList(CityData, "Id", "CityName", empcitytData.Id);
            ViewBag.DistrictList = new SelectList(DistrictData, "Id", "DistrictName", dataVM.DistrictId);

            return View(dataVM);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(model);
                    string FileName = FilesHelper.Upload(model.PhotoUrl, "Photos");
                    string FileNameCv = FilesHelper.Upload(model.CvUrl, "Docs");
                    data.PhotoName = FileName;
                    data.CvName = FileNameCv;
                    EmployeeRep.Update(data);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                var DepData = DepartmentRep.Get();
                var CountryData = CountryRep.Get();



                var empcitytData = CityRep.GetById(model.District.CityId);
                var empcountrytData = CountryRep.GetById(empcitytData.CountryId);

                var CityData = CityRep.GetCityByCountry(empcountrytData.Id);
                var DistrictData = DistrictRep.GetDistrictByCity(empcitytData.Id);



                ViewBag.DepartmentList = new SelectList(DepData, "Id", "DepartmentName", model.DepartmentId);
                ViewBag.CountryList = new SelectList(CountryData, "Id", "CountryName", empcountrytData.Id);


                ViewBag.CityList = new SelectList(CityData, "Id", "CityName", empcitytData.Id);
                ViewBag.DistrictList = new SelectList(DistrictData, "Id", "DistrictName", model.DistrictId);

                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var Data = EmployeeRep.GetById(Id);

            var dataVM = mapper.Map<EmployeeVM>(Data);
            return View(dataVM);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int Id)
        {
            try
            {
                var data = EmployeeRep.GetById(Id);
                FilesHelper.Remove("Photos/", data.PhotoName);
                FilesHelper.Remove("Docs/",data.CvName);
                EmployeeRep.Delete(Id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }

        }

        #endregion

        #region AjaxCall
        [HttpPost]
        public JsonResult GetCityByCountryID(int CountryID)
        {
            var data = CityRep.Get().Where(a => a.CountryId == CountryID);
            return Json(data);
        }
        [HttpPost]
        public JsonResult GetDistrictByCityID (int CityID)
        {
            var data = DistrictRep.Get().Where(a => a.CityId == CityID);
            return Json(data);
        }
        #endregion
    }
}
