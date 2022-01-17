using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Single = Housematica.Data.Data.CMS.Single;

namespace Housematica.NewWWW.Controllers
{
    public class BabylonComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Single single)
        {
            return View("BabylonComponent", single);
        }
    }
}
