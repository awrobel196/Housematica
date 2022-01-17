
using Housematica.Data.Data;
using Housematica.Intranet.Services.Interfaces;
using Housematica.Intranet.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intranet.Controllers
{
    public class ProjectsViewWidgetComponent : ViewComponent
    {
        private readonly HousematicaContext _context;
        public ProjectsViewWidgetComponent(HousematicaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid License)
        {

            if (!_context.ProjectsLicense.Where(x=>x.IdLicense== License).Any())
                return View("Empty");
            
            return View("ProjectsViewWidgetComponent");
        }

    }
}
