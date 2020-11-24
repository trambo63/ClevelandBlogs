using ClevelandBlogs.Models.CommentModels;
using ClevelandBlogs.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClevelandBlogs.WebMVC.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult IndexCategory()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            var model = service.GetCategories();
            return View(model);
        }
        public ActionResult GetAllPostsByCategoryId(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetAllPostByCategoryId(id);

            return View(model);
        }

        public ActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(CommentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCommentService();

            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Your comment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Comment could not be created.");

            return View(model);
        }

        public ActionResult GetAllCommentsByPostId(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetAllCommentsByPostId(id);

            return View(model);
        }

        public ActionResult DetailsComment(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);

            return View(model);
        }

        public ActionResult IndexAdd()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AddService(userId);
            var model = service.GetAdds();

            return View(model);
        }


        public ActionResult DetailsPost(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);

            return View(model);
        }

        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;
        }

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }

        private AddService CreateAddService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AddService(userId);
            return service;
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }
    }
}