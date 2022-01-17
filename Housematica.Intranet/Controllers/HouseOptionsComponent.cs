
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
    public class HouseOptionsComponent : ViewComponent
    {
       

        public HouseOptionsComponent()
        {
           
        }
      
        public async Task<IViewComponentResult> InvokeAsync(string name, int index)
        {
            ViewBag.Name = name;
            ViewBag.Index = index;
           
            return View("HouseOptionsComponent");
            //Koniec
        }

    }
}
