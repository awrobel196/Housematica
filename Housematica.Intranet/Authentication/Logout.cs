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
    public class Logout : Controller
    {

  
        [HttpGet("Logout")]
        public async Task<IActionResult> TryLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
