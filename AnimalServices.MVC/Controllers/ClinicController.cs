using AnimalServices.Models.Clinic;
using AnimalServices.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalServices.MVC.Controllers
{
    [Authorize]
    public class ClinicController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClinicService(userId);
            var model = service.GetClinics();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClinicCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClinicService();

            if (service.CreateClinic(model))
            {
                TempData["SaveResult"] = "Your clinic was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Clinic could not be created.");

            return View(model);
        }

        private ClinicService CreateClinicService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClinicService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateClinicService();
            var model = svc.GetClinicById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateClinicService();
            var detail = service.GetClinicById(id);
            var model =
                new ClinicEdit
                {
                    Name = detail.Name,
                    Address = detail.Address,
                    ClinicType = detail.ClinicType,
                    
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClinicEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClinicId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateClinicService();

            if (service.UpdateClinic(model))
            {
                TempData["SaveResult"] = "Your clinic was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your clinic could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateClinicService();
            var model = svc.GetClinicById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClinicService();

            service.DeleteClinic(id);

            TempData["SaveResult"] = "Your clinic was deleted";

            return RedirectToAction("Index");
        }
    }
}