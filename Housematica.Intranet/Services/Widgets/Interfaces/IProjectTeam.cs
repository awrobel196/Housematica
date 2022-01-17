using Housematica.Intranet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.Services.Interfaces
{
    public interface IProjectTeam
    {
      
        public List<TeamWidgetViewModel> getProjectTeam(Guid License);
       
    }
}
