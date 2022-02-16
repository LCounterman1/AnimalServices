using AnimalServices.Models.Animal;
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
    public class AnimalController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnimalService(userId);
            var model = service.GetAnimals();
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
            if (!ModelState.IsValid) return View(model);

            var service = CreateAnimalService();

            if (service.CreateAnimal(model))
            {
                TempData["SaveResult"] = "Your animal was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Animal could not be created.");

            return View(model);
        }

        

        public ActionResult Details(int id)
        {
            var svc = CreateAnimalService();
            var model = svc.GetAnimalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAnimalService();
            var detail = service.GetAnimalById(id);
            var model =
                new AnimalEdit
                {
                    AnimalId = detail.AnimalId,
                    Name = detail.Name,
                    Weight = detail.Weight,
                    State = detail.State,
                    IsBred = detail.IsBred,
                   
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public ActionResult Edit(int id, AnimalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AnimalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAnimalService();

            if (service.UpdateAnimal(model))
            {
                TempData["SaveResult"  ] = "Your animal was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your animal could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAnimalService();
            var model = svc.GetAnimalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAnimalService();

            service.DeleteAnimal(id);

            TempData["SaveResult"] = "Your animal was deleted";

            return RedirectToAction("Index");
        }

        private AnimalService CreateAnimalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnimalService(userId);
            return service;
        }
    }
}