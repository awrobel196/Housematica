using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.ViewModel
{
    public class LicenseWidgetViewModel
    {
            public double UserAvailable { get; set; }
            public double PercentageLicenseUsing { get; set; }
            public double ProjectsAvailable { get; set; }
            public double VariantsAvailable { get; set; }
            public string LicenseExpired { get; set; }
    
    }
}
