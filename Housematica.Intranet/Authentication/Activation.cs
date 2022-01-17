using Housematica.Data.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.Authentication
{
    [Route("Authentication")]
    public class Activation: Controller
    {

        private readonly HousematicaContext _context;

        public Activation(HousematicaContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Activate/{userId}")]
        public IActionResult Activate([FromRoute] Guid userId)
        {
            var user = _context.User.Where(x => x.IdUser == userId).FirstOrDefault();
            user.isActivate = true;
            _context.SaveChanges();
            TempData["Message"] = "Activation";
            var claims = User.Identities.FirstOrDefault()?.Claims.FirstOrDefault()?.Value;
            if(claims is null)
            {
                
                return RedirectToAction("Login", "Home");
            }
            else
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Login", "Home");
            }
        
        }
        
    }
}
