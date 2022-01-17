
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
    public class LicenseWidgetComponent : ViewComponent
    {
        private readonly ILicense _license;

        public LicenseWidgetComponent(ILicense license)
        {
            _license = license;
        }
      
        public async Task<IViewComponentResult> InvokeAsync(Guid License)
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            LicenseWidgetViewModel licenseWidget = new LicenseWidgetViewModel();
            licenseWidget.UserAvailable = _license.userAvailable(License);
            licenseWidget.PercentageLicenseUsing = _license.percentageLicenseUsing(License);
            licenseWidget.ProjectsAvailable = _license.projectAvailable(License);
            licenseWidget.VariantsAvailable = _license.variantsAvailable(License);
            licenseWidget.LicenseExpired = _license.licenseExpired(License);
            timer.Stop();
            var time = timer.ElapsedMilliseconds;
            return View("LicenseWidgetComponent", licenseWidget);
        }

    }
}
