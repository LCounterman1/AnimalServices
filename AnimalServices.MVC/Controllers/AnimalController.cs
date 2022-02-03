using AnimalServices.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalServices.MVC.Controllers
{
    [Authorize]
    public class AnimalController : Controller
    {
        public ActionResult Index()
        {
            var model = new AnimalListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}