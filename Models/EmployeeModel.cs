using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlExamples.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepId { get; set; }
        public string DepName { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Hobbies { get; set; }
        public string Ephoto { get; set; }

        //public List<EmployeeModel> GetEmployeeDetails()
        //{

        //}
    }
}