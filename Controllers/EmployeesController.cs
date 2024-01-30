using ControlExamples.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlExamples.Controllers
{
    public class EmployeesController : Controller
    {
        MyAppDBEntities db = new MyAppDBEntities();

        // GET: Employees
        public ActionResult ViewAllEmployees()
        {
            var data = db.tblEmployees.ToList();


            return View(data);
        }

        public ActionResult AddEmployee()
        {
            ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(FormCollection fc)
        {
            //get data from view
            tblEmployee employee = new tblEmployee();
            employee.empName = fc["empName"];
            employee.depName = fc["depName"];
            employee.designation = fc["designation"];

            //save data into database using entity fw
            db.tblEmployees.Add(employee);
            db.SaveChanges();

            ViewBag.msg = "employee details saved successfully";

            return View();
        }
    }
}