using ClevelandBlogs.Models.AddModels;
using ClevelandBlogs.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClevelandBlogs.WebMVC.Controllers
{
    [Authorize]
    public class AddController : Controller
    {
        // GET: Add
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AddService(userId);
            var model = service.GetAdds();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAddService();

            if (service.CreateAdd(model))
            {
                TempData["SaveResult"] = "Your add was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Reply add not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAddService();
            var model = svc.GetAddById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAddService();
            var detail = service.GetAddById(id);
            var model =
                new AddEdit
                {
                    AddId = detail.AddId,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AddId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAddService();

            if (service.UpdateAdd(model))
            {
                TempData["SaveResult"] = "Your add was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your add could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAddService();
            var model = svc.GetAddById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAdd(int id)
        {
            var service = CreateAddService();

            service.DeleteAdd(id);

            TempData["SaveResult"] = "Your add was deleted";

            return RedirectToAction("Index");
        }

        private AddService CreateAddService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AddService(userId);
            return service;
        }
    }
}