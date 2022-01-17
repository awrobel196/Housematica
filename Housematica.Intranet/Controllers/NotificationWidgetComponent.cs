
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
    public class NotificationWidgetComponent : ViewComponent
    {
        private readonly ILicense _license;
        private readonly HousematicaContext _context;

        public NotificationWidgetComponent(ILicense license, HousematicaContext context)
        {
            _license = license;
            _context = context;
        }
      
        public async Task<IViewComponentResult> InvokeAsync(Guid User)
        {
            var notificationList = _context.Notification.Take(8).ToList();
           
            return View("NotificationWidgetComponent", notificationList);
            //Koniec
        }

    }
}
