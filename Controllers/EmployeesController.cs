using ControlExamples.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ControlExamples.Models;

namespace ControlExamples.Controllers
{
    public class EmployeesController : Controller
    {
        MyAppDBEntities db = new MyAppDBEntities();

        // GET: Employees
        public ActionResult ViewAllEmployees()
        {
            var data = from emp in db.tblEmployees
                       join dep in db.tblDepartments on emp.depId equals dep.depId
                       select new
                       {
                          emp,dep
                       };

            var list = new List<EmployeeModel>();

            foreach (var item in data)
            {
                EmployeeModel em = new EmployeeModel();
                em.DepId = item.dep.depId;
                em.DepName = item.dep.depName;
                em.Id = item.emp.empId;
                em.Name = item.emp.empName;
                em.Hobbies = item.emp.hobbies;
                em.Gender = item.emp.gender;
                em.Ephoto = item.emp.ephoto;
                em.Designation = item.emp.designation;

                list.Add(em);
            }

            return View(list);
        }

        public ActionResult AddEmployee()
        {
            ViewBag.departments = db.tblDepartments.ToList();
            ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(FormCollection fc, HttpPostedFileBase uploadedFiles)
        {
            ViewBag.departments = db.tblDepartments.ToList();

            //get data from view
            tblEmployee employee = new tblEmployee();
            employee.empName = fc["empName"];
            employee.depId = Convert.ToInt32(fc["depId"]);
            employee.designation = fc["designation"];
            employee.hobbies = fc["hby"];
            employee.gender = fc["rdo"];

            //to save file use below code
            employee.ephoto = "/EmployeePhotos/" + uploadedFiles.FileName;
            uploadedFiles.SaveAs(Server.MapPath(employee.ephoto));

            //save data into database using entity fw
            db.tblEmployees.Add(employee);
            db.SaveChanges();

            ViewBag.msg = "employee details saved successfully";

            return View();
            // return RedirectToAction("ViewAllEmployees");
        }
    }
}