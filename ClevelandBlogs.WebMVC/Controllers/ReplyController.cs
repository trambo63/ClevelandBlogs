using ClevelandBlogs.Models.ReplyModels;
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
    public class ReplyController : Controller
    {
        // GET: Reply
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyService(userId);
            var model = service.GetReplies();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReplyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReplyService();

            if (service.CreateReply(model))
            {
                TempData["SaveResult"] = "Your reply was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Reply could not be created.");

            return View(model);
        }

        
        public ActionResult Details(int id)
        {
            var svc = CreateReplyService();
            var model = svc.GetReplyById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateReplyService();
            var detail = service.GetReplyById(id);
            var model =
                new ReplyEdit
                {
                    ReplyId = detail.ReplyId,
                    CommentId = detail.CommentId,
                    Content = detail.Content
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReplyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReplyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateReplyService();

            if (service.UpdateReply(model))
            {
                TempData["SaveResult"] = "Your reply was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your reply could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReplyService();
            var model = svc.GetReplyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReply(int id)
        {
            var service = CreateReplyService();

            service.DeleteReply(id);

            TempData["SaveResult"] = "Your reply was deleted";

            return RedirectToAction("Index");
        }

        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyService(userId);
            return service;
        }
    }
}