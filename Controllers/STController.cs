using ControlExamples.EF;
using ControlExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlExamples.Controllers
{
    public class STController : Controller
    {

        private MyAppDBEntities db = new MyAppDBEntities();

        // GET: ST
        public ActionResult Index()
        {
            var emp = new EmployeeModel
            {
                Name = "yagnesh",
                DepId= 1002
            };

            ViewBag.departmentList = db.tblDepartments.ToList();



            return View(emp);
        }

        [HttpPost]
        public ActionResult Index(EmployeeModel em,FormCollection fc)
        {
            
            return View();
        }
    }
}