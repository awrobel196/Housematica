using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Housematica.Data.Data;
using System.Collections.Generic;
using System;
using Housematica.Data.Data.CMS;
using Microsoft.EntityFrameworkCore;
using Single = Housematica.Data.Data.CMS.Single;
namespace Housematica.NewWWW.Services
{
    [Route("")]
    public class RouteService : Controller
    {
        private readonly HousematicaContext _context;
        private ShowreelForView _showreelForView { get; set; }
        

        public RouteService(HousematicaContext context)
        {
            _context = context;
          
        }

        [HttpGet("{id}-{mode}")]
        public ActionResult Route(string id, string mode)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _showreelForView = new ShowreelForView(id, _context);

            var showreel = _showreelForView.GetData();

            stopwatch.Stop();
            var a = stopwatch.ElapsedMilliseconds;
            if (showreel is null)
            {
                return RedirectToAction("DetailsFrame", "Projects", new { id = id });
            }
            else
            {
                return View("../Showreel/DetailsFrame", showreel);
            }
            
        }


        [HttpGet("{id}")]
        public ActionResult Route(string id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var showreel = _context.Single.Where(x => x.SingleGuid.ToString().Substring(0, 8) == id).Include(x => x.Projects).ThenInclude(x => x.ProjectType).Include(x => x.SingleFloor).ThenInclude(x => x.SingleRooms).FirstOrDefault();

           

            stopwatch.Stop();
            var a = stopwatch.ElapsedMilliseconds;
            if (showreel is null)
            {

           
               
                return RedirectToAction("Details", "Projects", new { id=id});
            }
            else
            {
                return View("../Showreel/Details", showreel);
            }

        }


      

        
    }
}
