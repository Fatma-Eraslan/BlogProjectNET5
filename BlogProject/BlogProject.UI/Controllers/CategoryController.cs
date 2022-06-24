using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogProject.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICoreService<Category> categoryService;
        private readonly ICoreService<Post> postService;
        private readonly ICoreService<User> userService;

        public CategoryController(ICoreService<Category> categoryService, ICoreService<Post> postService, ICoreService<User> userService)
        {            
            this.categoryService = categoryService;
            this.postService = postService;
            this.userService = userService;
        }
       
       

    }
}
