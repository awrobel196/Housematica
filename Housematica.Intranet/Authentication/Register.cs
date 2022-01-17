using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Housematica.Intranet.Models;
using Housematica.Data.Data;
using System.Collections.Generic;
using System;
using Housematica.Data.Data.CMS;

namespace Housematica.Intranet.Authentication
{
    [Route("Authentication")]
    public class Register : Controller
    {
        private readonly HousematicaContext _context;

        public Register(HousematicaContext context)
        {
            _context = context;
        }

        [HttpGet("Invite/{licenseId}")]
        public IActionResult RegisterFromInvite([FromRoute] Guid licenseId)
        {
            return View("~/Views/Home/Invite.cshtml",licenseId);
        }

        [HttpPost("Register")]
        public JsonResult TryRegister(User user)
        {
            Random avatarNumber = new Random();

            if(user.IdLicense == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                user.License = new License();
                user.License.IdLicenseType = _context.LicenseType.Where(x => x.IsDemo == true).Select(x => x.IdLicenseType).FirstOrDefault();
                user.License.IdLicense = Guid.NewGuid();
                user.License.Expire = DateTime.Now.AddDays(30);
                user.IdLicense = user.License.IdLicense;
            
            }

            if (user.name.EndsWith("a"))
            {
                user.avatar = $"girl-{avatarNumber.Next(0,22)}.svg";
            }
            else
            {
                user.avatar = $"boy-{avatarNumber.Next(0, 22)}.svg";
            }

            user.IdUser = Guid.NewGuid();
         
            user.isActivate = false;
            
          

            _context.User.Add(user);
            _context.SaveChanges();
            return Json(user.IdUser);
        }


        


    }
}
