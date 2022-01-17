
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
    public class TeamWidgetComponent : ViewComponent
    {
        private readonly IProjectTeam _projectTeam;
        private readonly HousematicaContext _context;
        public TeamWidgetComponent(IProjectTeam projectTeam, HousematicaContext context)
        {
            _projectTeam = projectTeam;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid License)
        {
            var projectTeam = _projectTeam.getProjectTeam(License);

            if (projectTeam.Count()<=1)
                return View("Empty");
            
            return View("TeamWidgetComponent", projectTeam);
        }

    }
}
