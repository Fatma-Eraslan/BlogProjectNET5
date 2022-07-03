using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.UI.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BlogProject.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class PostController : Controller
    {
        private readonly ICoreService<Category> categoryService;
        private readonly ICoreService<Post> postService;
        private readonly ICoreService<User> userService;
        public PostController(ICoreService<Category> categoryService, ICoreService<Post> postService, ICoreService<User> userService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.userService = userService;
        }
        public IActionResult ListPost()
        {
            return View(postService.GetAll());
        }
        public IActionResult AddPost()
        {
            //Addpost view gösterecek
            ViewBag.Categories = categoryService.GetActive();
            ViewBag.Users = userService.GetActive();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(IFormCollection gelenMakale)
        {
            Post eklenecekPost = new Post();
            eklenecekPost.Title = gelenMakale["title"];
            eklenecekPost.PostDetail = gelenMakale["detail"];
            eklenecekPost.Tags = gelenMakale["tags"];
            eklenecekPost.ImagePath = gelenMakale["imagePath"];
            eklenecekPost.ViewCount = Convert.ToInt32(gelenMakale["viewCount"]);
            eklenecekPost.CategoryID = Guid.Parse(gelenMakale["categoryId"]);
            eklenecekPost.UserID = Guid.Parse(gelenMakale["userId"]);
            if (ModelState.IsValid)
            {

                return RedirectToAction(nameof(ListPost));
            }
            return View(gelenMakale);
        }

        public IActionResult ActivatePost(Guid id)
        {
            postService.Activate(id);
            return RedirectToAction("ListPost");
        }
    }
}
