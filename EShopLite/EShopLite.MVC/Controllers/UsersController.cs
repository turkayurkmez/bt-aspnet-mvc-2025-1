using EShopLite.Application;
using EShopLite.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EShopLite.MVC.Controllers
{
    public class UsersController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? gidilecekSayfa)
        {
            UserLoginViewModel model = new UserLoginViewModel() { ReturnUrl=gidilecekSayfa};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model, string? gidilecekSayfa)
        {
            if (ModelState.IsValid)
            {
                //kullanıcı adı ve şifre kontrolü
                var user = userService.ValidateUser(model.UserName, model.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("Takim", "FB"),
                        new Claim(ClaimTypes.Role, user.Role)

                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (!string.IsNullOrEmpty(gidilecekSayfa) && Url.IsLocalUrl(gidilecekSayfa))
                    {
                        return Redirect(gidilecekSayfa);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }

                }

                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");             



            }
            return View(model);
        }


    }
}
