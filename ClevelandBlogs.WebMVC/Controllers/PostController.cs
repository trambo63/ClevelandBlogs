using ClevelandBlogs.Models;
using ClevelandBlogs.Models.PostModels;
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
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            var model = service.GetPosts();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePostService();

            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Your Blog Post was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Blog Post could not be created.");

            return View(model);
        }

        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
    }
}