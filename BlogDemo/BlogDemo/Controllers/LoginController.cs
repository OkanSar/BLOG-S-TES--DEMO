using BlogDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(p.username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, p.password, false, true);
                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (roles.Contains("Writer"))
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Blog");
                        }
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
