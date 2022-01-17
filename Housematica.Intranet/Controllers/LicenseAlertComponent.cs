
using Housematica.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    public class LicenseAlertComponent : ViewComponent
    {
        private readonly HousematicaContext _context;
        public LicenseAlertComponent(HousematicaContext context)
        {
            _context = context;
        }
      
        public async Task<IViewComponentResult> InvokeAsync(string idUser)
        {
            var licenseDemo = await _context.User.Where(x => x.IdUser.ToString() == idUser).Select(x => x.License.LicenseType.IsDemo).FirstOrDefaultAsync();

            if(licenseDemo == true)
            {
                return View("LicenseAlertComponent");
            }

            return Content(string.Empty);
            //PiesNaGlancContext context = new PiesNaGlancContext();

           

        }
  
    }
}
