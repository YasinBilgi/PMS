using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.Entities.Models;
using PMS.WebUI.Models;
using System.Security.Claims;
using System.Security.Principal;
using Utility;

namespace PMS.WebUI.Controllers
{
    public class AccountController : Controller //Login
    {
        PmsContext context = new PmsContext();

        public IActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Doğrula
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                ViewBag.Message = "Kullanıcı bulunamadı";
                return View(model);
            }

            //Email Send
            await MailSender.SendLoginMail(model.Email);

            //auth işlemleri
            var claims = new[] {
               new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
               new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return Redirect(new PathString("/managementpanel/dashboard/index"));
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

    }
}
