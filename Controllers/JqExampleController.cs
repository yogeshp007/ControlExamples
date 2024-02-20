using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlExamples.Controllers
{
    public class JqExampleController : Controller
    {
        // GET: JqExample
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var data = new { message = "this is from isro" };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}