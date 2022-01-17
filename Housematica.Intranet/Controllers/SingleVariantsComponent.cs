
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
    public class SingleVariantsComponent : ViewComponent
    {
       

        public SingleVariantsComponent()
        {
           
        }
      
        public async Task<IViewComponentResult> InvokeAsync()
        {

           
            return View("SingleVariantsComponent");
            //Koniec
        }

    }
}
