using AnimalServices.Models.HealthRecord;
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
    public class HealthRecordController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HealthRecordService(userId);
            var model = service.GetHealthRecords();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HealthRecordCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHealthRecordService();

            if (service.CreateHealthRecord(model))
            {
                TempData["SaveResult"] = "Your health record was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Health record could not be created.");

            return View(model);
        }


        public ActionResult Details(int id)
        {
            var svc = CreateHealthRecordService();
            var model = svc.GetHealthRecordById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHealthRecordService();
            var detail = service.GetHealthRecordById(id);
            var model =
                new HealthRecordEdit
                {
                    HealthRecordId = detail.HealthRecordId,
                    AnimalId = detail.AnimalId,
                    Comments = detail.Comments,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HealthRecordEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HealthRecordId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHealthRecordService();

            if (service.UpdateHealthRecord(model))
            {
                TempData["SaveResult"] = "Your health record was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your health record could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateHealthRecordService();
            var model = svc.GetHealthRecordById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHealthRecordService();

            service.DeleteHealthRecord(id);

            TempData["SaveResult"] = "Your health record was deleted";

            return RedirectToAction("Index");
        }

        private HealthRecordService CreateHealthRecordService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HealthRecordService(userId);
            return service;
        }
    }
}