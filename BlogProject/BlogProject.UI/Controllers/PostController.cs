using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            ViewBag.RandomPosts = postService.GetActive().Where(x=>x.CategoryID==postService.GetByID(id).CategoryID).Take(3).ToList();
            return View(singlePostVM);
        }

        public IActionResult PostByAuthor(Guid id)
        {
            ViewBag.Author = userService.GetByID(id).FirstName + " " + userService.GetByID(id).LastName;
            return View(postService.GetDefault(x=>x.UserID==id));
        }
        
        public IActionResult PostByCategory(Guid id)
        {
            PostUserVM postUserVM = new PostUserVM();
            postUserVM.Posts = postService.GetDefault(x => x.CategoryID == id);
            postUserVM.Users = userService.GetAll();
            return View(postUserVM);
        }

        [HttpPost]
        public IActionResult PostBySearch(string query)
        {
            PostUserVM postUserVM = new PostUserVM();
            postUserVM.Posts = postService.GetDefault(x => x.Title.Contains(query));
            postUserVM.Users = userService.GetAll();
            return View(postUserVM);
        }
    }
}
