using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Housematica.Intranet.Models;
using Housematica.Data.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System;

namespace Housematica.Intranet.Authentication
{
   
    [Route("Authentication")]
    public class Login : Controller
    {
        private readonly HousematicaContext _context;
        public Login(HousematicaContext context)
        {
            _context = context;
        }

        [HttpPost("Login")]
        public JsonResult TryLogin(string email, string password)
        {
            var user = _context.User.Where(x => x.email == email).Where(p => p.password == password).ToList();
            if (user.Count > 0)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Select(x=>x.IdUser).FirstOrDefault().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Select(x=>x.IdLicense).FirstOrDefault().ToString()),
                };
                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
