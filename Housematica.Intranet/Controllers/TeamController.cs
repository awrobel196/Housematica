using Housematica.Data.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Housematica.Intranet.Controllers
{
    public class TeamController : Controller
    {
        private readonly HousematicaContext _context;
        public TeamController(HousematicaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            ViewBag.License = license;

            var query = _context.User.Where(x => x.IdLicense == new Guid(license)).ToList();





            return View(query);
        }
    }
}
