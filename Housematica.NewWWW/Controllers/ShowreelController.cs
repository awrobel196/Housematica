using Dapper;
using Housematica.Data.Data;
using Housematica.Data.Data.CMS;
using Housematica.WWW.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Single = Housematica.Data.Data.CMS.Single;

namespace Housematica.NewWWW.Controllers
{
    public class ShowreelController : Controller
    {
        private readonly HousematicaContext _context;

        public ShowreelController(HousematicaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Single showreel)
        {
           
            //Guid projectId = _context.Single.Where(x => x.SingleGuid == id).Select(x => x.IdProjects).FirstOrDefault();
            //AddViewDto addViewDto = new AddViewDto(_context);
            //AddUViewDto addUViewDto = new AddUViewDto(_context);
            //AddClickDto addClickDto = new AddClickDto(_context);
            //var a = Request.Cookies["housematicaView"];

            //if (Request.Cookies["housematicaView"] is null)
            //{
            //    string key = "housematicaView";
            //    string value = "thisisvalue";
            //    CookieOptions cookieOptions = new CookieOptions();
            //    cookieOptions.Expires = DateTime.Now.AddMinutes(10);
            //    Response.Cookies.Append(key, value, cookieOptions);
            //    await addViewDto.AddNewView(projectId);
            //    await addClickDto.AddNewClick(projectId);
            //    await addUViewDto.AddNewView(projectId);

            //}
            //else
            //{
            //    await addViewDto.AddNewView(projectId);
            //    await addClickDto.AddNewClick(projectId);
            //}

            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["HousematicaContext"].ConnectionString))
            //{
            //    var elo =  db.Query<Single>
            //    ("SELECT [s].[SingleGuid], [s].[Area], [s].[AreaBuild], [s].[IdProjects], [s].[Image], [s].[Name], [s].[NumberOfFloor], [s].[Price], [s].[Status], [p].[IdProject], [p].[IdProjectType], [p].[IsActive], [p].[IsDelete], [p].[IsValidate], [p].[OwnerName], [p].[ProjectAdress1], [p].[ProjectAdress2], [p].[ProjectCity], [p].[ProjectCountry], [p].[ProjectDescription], [p].[ProjectName], [p].[ProjectPostcode], [p].[ProjectState], [p0].[IdProjectType], [p0].[ConfiguratorType], [p0].[Description], [p0].[Name], [t].[IdSingleFloor], [t].[BalconyArea], [t].[FloorArea], [t].[FloorModel], [t].[FloorPlan], [t].[IdSingle], [t].[NumberOfLivingRoom], [t].[TerraceArea], [t].[IdSingleRoom], [t].[IdSingleFloors], [t].[RoomArea], [t].[RoomName] FROM[Single] AS[s] INNER JOIN[Projects] AS[p] ON[s].[IdProjects] = [p].[IdProject] INNER JOIN[ProjectType] AS[p0] ON[p].[IdProjectType] = [p0].[IdProjectType] LEFT JOIN(SELECT[s0].[IdSingleFloor], [s0].[BalconyArea], [s0].[FloorArea], [s0].[FloorModel], [s0].[FloorPlan], [s0].[IdSingle], [s0].[NumberOfLivingRoom], [s0].[TerraceArea], [s1].[IdSingleRoom], [s1].[IdSingleFloors], [s1].[RoomArea], [s1].[RoomName] FROM[SingleFloor] AS[s0] LEFT JOIN[SingleRooms] AS[s1] ON[s0].[IdSingleFloor] = [s1].[IdSingleFloors]) AS[t] ON[s].[SingleGuid] = [t].[IdSingle] WHERE[s].[SingleGuid] = 'd789625e-e280-4418-c252-08d91a2473f7' ORDER BY[s].[SingleGuid], [p].[IdProject], [p0].[IdProjectType], [t].[IdSingleFloor], [t].[IdSingleRoom]").FirstOrDefault();
            //}

            //var showrrel = _context.Single.Where(x => x.SingleGuid == id).Include(x => x.Projects).ThenInclude(x=>x.ProjectType).Include(x => x.SingleFloor).ThenInclude(x => x.SingleRooms).FirstOrDefault();


       
            return View(showreel);

        }


        public async Task<IActionResult> DetailsFrame(Single showreel)
        {

         


            return View(showreel);

        }
    }
}
