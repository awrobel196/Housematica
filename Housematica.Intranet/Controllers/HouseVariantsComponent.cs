
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
    public class HouseVariantsComponent : ViewComponent
    {
       

        public HouseVariantsComponent()
        {
           
        }
      
        public async Task<IViewComponentResult> InvokeAsync()
        {

           
            return View("HouseVariantsComponent");
            //Koniec
        }

    }
}
