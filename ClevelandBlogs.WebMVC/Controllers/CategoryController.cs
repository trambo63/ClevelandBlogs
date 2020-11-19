using ClevelandBlogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClevelandBlogs.WebMVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var model = new CategoryListItem[0];
            //Note: In the code above, we are initializing a new instance of the NoteListItem as an IEnumerable with the [0] syntax. This will satisfy some of the requirements for our Index View. When we added the List template for our view, it created some IEnumerable requirements for our list view. More on that later.
            return View(model);
        }

        //GET 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}