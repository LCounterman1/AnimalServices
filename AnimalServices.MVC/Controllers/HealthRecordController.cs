using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalServices.MVC.Controllers
{
    public class HealthRecordController : Controller
    {
        // GET: HealthRecord
        public ActionResult Index()
        {
            return View();
        }
    }
}