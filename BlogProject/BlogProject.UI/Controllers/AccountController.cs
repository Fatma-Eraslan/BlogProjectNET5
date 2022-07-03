using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<User> userService;

        public AccountController(ICoreService<User> userService)
        {           
            this.userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User item)
        {
            if (userService.Any(x => x.EmailAddress == item.EmailAddress && x.Password == item.Password))
            {
                User logged = userService.GetByDefault(x => x.EmailAddress == item.EmailAddress && x.Password == item.Password);
                var claims = new List<Claim>()
                {
                    new Claim("ID",logged.ID.ToString()),
                    new Claim(ClaimTypes.Name,logged.FirstName),
                    new Claim(ClaimTypes.Surname,logged.LastName),
                    new Claim(ClaimTypes.Email,logged.EmailAddress),
                    new Claim("Image",logged.ImageURL)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(item);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
