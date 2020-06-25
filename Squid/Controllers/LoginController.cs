using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Squid.Viewmodels;

namespace Squid.Controllers
{
    public class LoginController : Controller
    {
        public LoginLogic _loginLogic;

        public LoginController()
        {
            _loginLogic = new LoginLogic();
        }

        //LoginPage
        public IActionResult Index()
        {
            var viewmodel = new LoginViewmodel();
            return View(viewmodel);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewmodel viewmodel)
        {
            var user = viewmodel.user;
            var result = _loginLogic.ValidateUser(user.Username, user.PasswordHash);
            if (result != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.Username)
                };
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(360)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Menu");
            }

            return View("Index", viewmodel);
        }
    }
}
