
using AdminDash.BL.Interfaces;
using AdminDash.BL.Repository;
using AdminDash.DAL.Entities;
using AdminDash.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDash.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRep DepartmentRp;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRep DepartmentRp, IMapper mapper)
        {
            this.DepartmentRp = DepartmentRp;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = mapper.Map<IEnumerable<DepartmentVM>>(DepartmentRp.Get());
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data =  mapper.Map<Department>(model);
                    DepartmentRp.Add(data);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                //EventLog log = new EventLog();
                //log.Source = "AdminDash";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(model);
            }

        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
          var Data= DepartmentRp.GetById(Id);
            var dataVM = mapper.Map<DepartmentVM>(Data);
          return View(dataVM);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  var data =  mapper.Map<Department>(model);
                    DepartmentRp.Update(data);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                //EventLog log = new EventLog();
                //log.Source = "AdminDash";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var Data = DepartmentRp.GetById(Id);

            var dataVM = mapper.Map<DepartmentVM>(Data);
            return View(dataVM);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int Id)
        {
            try
            {

                    DepartmentRp.Delete(Id);

                    return RedirectToAction("Index");
     
            }
            catch (Exception ex)
            {
                //EventLog log = new EventLog();
                //log.Source = "AdminDash";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return RedirectToAction("Index");
            }

        }
    }
}
