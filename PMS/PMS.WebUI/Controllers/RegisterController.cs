using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.Entities.Models;
using System.Security.Claims;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Utility;

namespace PMS.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        PmsContext context = new PmsContext();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                //Veri tabanına kayıt işlemleri
                await context.Users.AddAsync(model);
                await context.SaveChangesAsync();

                //Email Send
                await MailSender.SendRegisterMail(model.Email);
                
                //auth işlemleri
               var claims = new[] {
               new Claim(ClaimTypes.Name, model.FirstName + " " + model.LastName),
               new Claim(ClaimTypes.Role, model.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return Redirect(new PathString("/managementpanel/dashboard/index"));
            }
                return View(model);
        }
    }
}
