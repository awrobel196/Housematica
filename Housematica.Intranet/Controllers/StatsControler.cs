using Housematica.Data.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Housematica.Data.Data.CMS.Statistics;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Housematica.Intranet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsControler : Controller
    {
        private readonly HousematicaContext _context;

        public StatsControler(HousematicaContext context)
        {
            _context = context;
        }

        [Route("GetViews/{License}")]
        [HttpPost]
        public IActionResult GetViews([FromRoute] Guid License)
        { 
            var customer = _context.Get<Views>(x => x.Projects.ProjectsLicense.Where(x => x.IdLicense == License).Any());


            var jsonRoomList = JsonConvert.SerializeObject(customer,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

      
            return Content(jsonRoomList, "application/json");


        }



        [Route("GetUViews/{License}")]
        [HttpPost]
        public IActionResult GetUViews([FromRoute] Guid License)
        {
  
            var customer = _context.Get<UViews>(x => x.Projects.ProjectsLicense.Where(x => x.IdLicense == License).Any());

            var jsonRoomList = JsonConvert.SerializeObject(customer,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
         
            return Content(jsonRoomList, "application/json");


        }


        [Route("GetTotalConfiguration/{License}")]
        [HttpPost]
        public IActionResult GetTotalConfiguration([FromRoute] Guid License)
        {
     

            var customer = _context.Get<TotalConfiguration>(x => x.Projects.ProjectsLicense.Where(x => x.IdLicense == License).Any());

            var jsonRoomList = JsonConvert.SerializeObject(customer,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

      
            return Content(jsonRoomList, "application/json");

        }




        [Route("GetCurrentProjectViews/{projectId}")]
        [HttpPost]
        public IActionResult GetCurrentProjectViews([FromRoute]Guid projectId)
        {


            Views views = new Views();
            views.January = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.January);
            views.February = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.February);
            views.March = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.March);
            views.April = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.April);
            views.May = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.May);
            views.June = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.June);
            views.July = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.July);
            views.August = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.August);
            views.September = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.September);
            views.October = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.October);
            views.November = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.November);
            views.December = _context.Views.Where(p => p.IdProjects == projectId).Sum(x => x.December);


            var jsonRoomList = JsonConvert.SerializeObject(views,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Content(jsonRoomList, "application/json");


        }






    }

}
