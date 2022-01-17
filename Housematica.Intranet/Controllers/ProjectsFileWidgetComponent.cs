
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
    public class ProjectsFileWidgetComponent : ViewComponent
    {
        private readonly HousematicaContext _context;
        public ProjectsFileWidgetComponent(HousematicaContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid License)
        {
            List<string> projectsFile = _context.ProjectsLicense.Where(x => x.IdLicense == License).Select(x => x.Projects.ProjectName).Take(2).ToList();
            if (!projectsFile.Any())
                return View("Empty");

            return View("ProjectsFileWidgetComponent", projectsFile);
        }

    }
}
