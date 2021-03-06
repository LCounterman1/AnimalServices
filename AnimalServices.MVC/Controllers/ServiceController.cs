using AnimalServices.Models.Service;
using AnimalServices.Models.Services;
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
    public class ServiceController : Controller
    {
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userID);
            var model = service.GetServices();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateServiceService();

            if (service.CreateService(model))
            {
                TempData["SaveResult"] = "Your service was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Service could not be created.");

            return View(model);
        }

        private ServiceService CreateServiceService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceService(userID);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateServiceService();
            var model = svc.GetServiceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateServiceService();
            var detail = service.GetServiceById(id);
            var model =
                new ServiceEdit
                {
                    ServiceId = detail.ServiceId,
                    ServiceType = detail.ServiceType,
                    Price = detail.Price,
                    Length = detail.Length,
        };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ServiceId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateServiceService();

            if (service.UpdateService(model))
            {
                TempData["SaveResult"] = "Your service was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your service could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateServiceService();
            var model = svc.GetServiceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateServiceService();

            service.DeleteService(id);

            TempData["SaveResult"] = "Your service was deleted";

            return RedirectToAction("Index");
        }
    }
}