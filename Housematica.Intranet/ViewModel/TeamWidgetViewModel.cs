using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.ViewModel
{
    public class TeamWidgetViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Avatar { get; set; }
        public bool IsActive { get; set; }
    }
}
