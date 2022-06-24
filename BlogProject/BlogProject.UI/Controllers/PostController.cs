using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogProject.UI.Controllers
{
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

        public IActionResult PostByID(Guid id)
        {
            SinglePostVM singlePostVM = new SinglePostVM();
            singlePostVM.Post = postService.GetByID(id);
            singlePostVM.User = userService.GetByDefault(x => x.ID == postService.GetByID(id).UserID);
            ViewBag.Categories = categoryService.GetActive();
            return View(singlePostVM);
        }

        public IActionResult PostByAuthor(Guid id)
        {
            ViewBag.Author = userService.GetByID(id).FirstName + " " + userService.GetByID(id).LastName;
            return View(postService.GetDefault(x=>x.UserID==id));
        }
    }
}
