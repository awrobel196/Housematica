using Housematica.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.ViewModel
{
    public class StatsViewModel
    {
       
        public int IdViews { get; set; }

        public Guid IdProjects { get; set; }

        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }


        public Projects Projects { get; set; }

    }
}

