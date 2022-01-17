using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.ViewModel
{
    public class ProjectEditViewModel
    {
            public int IdProject { get; set; }
            public string ProjectName { get; set; }
            public string ProjectDescription { get; set; }
            public string ContactPerson { get; set; }
            public string OwnerPhone { get; set; }
            public string OwnerAdress { get; set; }
            public string OwnerEmail { get; set; }
    }
}
