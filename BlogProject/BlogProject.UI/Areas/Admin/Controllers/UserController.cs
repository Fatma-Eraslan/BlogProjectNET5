using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]

    public class UserController : Controller
    {
        private readonly ICoreService<Category> categoryService;
        private readonly ICoreService<Post> postService;
        private readonly ICoreService<User> userService;
        public UserController(ICoreService<Category> categoryService, ICoreService<Post> postService, ICoreService<User> userService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
