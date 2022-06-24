using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.UI.Models;
using BlogProject.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICoreService<Category> categoryService;
        private readonly ICoreService<Post> postService;
        private readonly ICoreService<User> userService;

        public HomeController(ILogger<HomeController> logger, ICoreService<Category> categoryService, ICoreService<Post> postService, ICoreService<User> userService)
        {
            _logger = logger;
            this.categoryService = categoryService;
            this.postService = postService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            PostUserVM postUserVM = new PostUserVM();
            postUserVM.Posts = postService.GetActive();
            postUserVM.Users = userService.GetAll();
            ViewBag.Categories = categoryService.GetActive();
            return View(postUserVM);
        }

      





        public IActionResult Categories()
        {
            var categories = categoryService.GetAll();
            return View(categories);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
