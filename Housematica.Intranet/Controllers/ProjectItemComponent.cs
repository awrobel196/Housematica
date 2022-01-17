
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
    public class ProjectItemComponent : ViewComponent
    {
 

     
      
        public async Task<IViewComponentResult> InvokeAsync(ProjectsViewModel item)
        {

            if (item.ProjectType == "A")
            {
                return View("ApartmentComponent", item);
            }
            else if(item.ProjectType == "D")
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
