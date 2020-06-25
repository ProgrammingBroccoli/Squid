using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Squid.Controllers
{
    public class MenuController : Controller
    {
        public UserLogic _userLogic;

        public MenuController()
        {
            _userLogic = new UserLogic();
        }

        [Authorize]
        public IActionResult Index()
        {
            var username = HttpContext.User.Claims.First(i => i.Type == ClaimTypes.Name).Value;
            var user = _userLogic.GetUserByUsername(username);
            return View(user);
        }
    }
}
