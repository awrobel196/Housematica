using Housematica.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.WWW.DTO
{
    public class ApartmentAPI : Controller
    {
        private readonly HousematicaContext _context;

        public ApartmentAPI(HousematicaContext context)
        {
            _context = context;
        }

        [Route("api/{apartmentId}")]
        [HttpGet]
        public IActionResult Index(int apartmentId)
        {
          
            return RedirectToAction("Details","Apartment", new { id = apartmentId});
        }
    }
}
