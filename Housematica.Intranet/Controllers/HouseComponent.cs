
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
    public class HouseComponent : ViewComponent
    {
 

     
      
        public async Task<IViewComponentResult> InvokeAsync(ProjectsViewModel item)
        {
           
            return View("HouseComponent", item);
        }

    }
}
