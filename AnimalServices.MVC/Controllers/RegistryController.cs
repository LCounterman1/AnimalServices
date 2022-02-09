using AnimalServices.Models.Registry;
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
    public class RegistryController : Controller
    {
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RegistryService(userID);
            var model = service.GetRegistries();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRegistryService();

            if (service.CreateRegistry(model))
            {
                TempData["SaveResult"] = "Your registry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Registry could not be created.");

            return View(model);
        }

        private RegistryService CreateRegistryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RegistryService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRegistryService();
            var model = svc.GetRegistryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRegistryService();
            var detail = service.GetRegistryById(id);
            var model =
                new RegistryEdit
                {
                    
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RegistryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RegistryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRegistryService();

            if (service.UpdateRegistry(model))
            {
                TempData["SaveResult"] = "Your registry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your registry could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRegistryService();
            var model = svc.GetRegistryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRegistryService();

            service.DeleteRegistry(id);

            TempData["SaveResult"] = "Your registry was deleted";

            return RedirectToAction("Index");
        }
    }
}