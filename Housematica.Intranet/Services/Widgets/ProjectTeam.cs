using Housematica.Data.Data;
using Housematica.Intranet.Services.Interfaces;
using Housematica.Intranet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.Services
{
    public class ProjectTeam : IProjectTeam
    {
        private readonly HousematicaContext _context;
        public ProjectTeam(HousematicaContext context)
        {
            _context = context;
        }

        public List<TeamWidgetViewModel> getProjectTeam(Guid License)
        {

            var users= _context.User.Where(x=>x.IdLicense==License).Take(5).Select(x => new TeamWidgetViewModel
            {
                Name = x.name,
                Surname = x.surname,
                Email = x.email,
                IsActive = x.isActivate,
                Avatar = x.avatar


            }).ToList();

            return (users);
       
            //Koniec
        }
    }

}