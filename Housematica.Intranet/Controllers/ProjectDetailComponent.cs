
using Housematica.Data.Data;
using Housematica.Data.Data.CMS;
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
    public class ProjectDetailComponent : ViewComponent
    {
 

     
      
        public async Task<IViewComponentResult> InvokeAsync(Projects item)
        {

            if (item.ProjectType.ConfiguratorType == "A")
            {
                return View("ApartmentComponent", item);
            }
            else if(item.ProjectType.ConfiguratorType == "D")
            {
                return View("HouseComponent", item);
            }
            else
            {
                return View("SingleComponent", item);
            }
           
        }

    }
}
