using System;
using System.Collections.Generic;
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
using Microsoft.AspNetCore.Authorization;
using Housematica.Intranet.Services.Interfaces;
using Housematica.Intranet.ViewModel;

namespace Housematica.Intranet.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HousematicaContext _context;
        private readonly ILicense _license;

        public HomeController(ILogger<HomeController> logger, HousematicaContext context, ILicense license)
        {
            _license = license;
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var claims = User.Identities.FirstOrDefault()?.Claims.FirstOrDefault()?.Value;
            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            ViewBag.User = claims;
            ViewBag.License = license;
            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;
           

            return View();
        }

       

        public IActionResult Login() => View();

        public IActionResult Invite() => View();



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
