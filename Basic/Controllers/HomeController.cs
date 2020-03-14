using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var horneroClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "jesu"),
                new Claim(ClaimTypes.Email, "jesumarquez@gmail.com")
            };

            var horneroIdentity = new ClaimsIdentity(horneroClaims, "Hornero Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { horneroIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}