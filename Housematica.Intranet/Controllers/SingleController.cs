using FluentFTP;
using Housematica.Data.Data;
using Housematica.Data.Data.CMS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Single = Housematica.Data.Data.CMS.Single;

namespace Housematica.Intranet.Controllers
{
    public class SingleController : Controller
    {
        private HousematicaContext _context;
        private IConfiguration _configuration;

        public SingleController(HousematicaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {

            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            var apartments = _context.Single.Where(x => x.Projects.ProjectsLicense.Any(x => x.IdLicense == new Guid(license))).Include(x => x.Projects).Include(x => x.SingleFloor).ThenInclude(x=>x.SingleRooms).ToList();
            return View(apartments);
        }

        public IActionResult Create()
        {
            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            ViewBag.IdProjects = new SelectList(_context.Projects.Where(x => x.ProjectsLicense.Any(x => x.IdLicense == new Guid(license))).Where(x => x.IsDelete == false).Where(x => x.ProjectType.ConfiguratorType == "S"), "IdProject", "ProjectName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UploadFiles(IList<IFormFile> files, string projectName, string apartmentName, string modelType)
        {

           
            string secondPath = "/ftp.quirky-curie.188-34-164-7.plesk.page/cdn/" + projectName + "/" + apartmentName + "/" + modelType;
            // check if a file exists



            // create an FTP client
            FtpClient client = new FtpClient(_configuration["FTP:ServerPath"]);

            // specify the login credentials, unless you want to use the "anonymous" user account
            client.Credentials = new NetworkCredential(_configuration["FTP:Username"], _configuration["FTP:Password"]);

            // begin connecting to the server
            client.Connect();
            if (!client.DirectoryExists($"{secondPath}/"))
            {
                client.CreateDirectory(secondPath);
            }




            // upload a file

            if (files.Count() < 2)
            {
                foreach (IFormFile source in files)
                {
                    client.Upload(source.OpenReadStream(), $"{secondPath}/{source.FileName}");
                    return new JsonResult(source.FileName.ToString());
                }
            }else if (modelType == "SingleImage")
            {
                foreach (IFormFile source in files)
                {
                    client.Upload(source.OpenReadStream(), $"{secondPath}/{source.FileName}");
                    return new JsonResult(source.FileName.ToString());
                }
               
            }
            else
            {
                foreach (IFormFile source in files)
                {
                    client.Upload(source.OpenReadStream(), $"{secondPath}/{source.FileName}");
                }
            }

            // disconnect! good bye!
            client.Disconnect();

            var babylonModelName = files.Select(x => x.FileName).Where(x => x.EndsWith("babylon")).FirstOrDefault().ToString();
            //string secondPath = this.hostingEnv.WebRootPath +"\\" + projectName + "\\" + apartmentName + "\\" + modelType;
            //if (Directory.Exists(secondPath))
            //{
            //    Directory.Delete(secondPath, true);

            //}


            //foreach (IFormFile source in files)
            //{
            //    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

            //    filename = this.EnsureCorrectFilename(filename);

            //    using (FileStream output = System.IO.File.Create(this.GetPathAndFilename(filename,  projectName, apartmentName, modelType)))
            //        source.CopyTo(output);
            //}

            return new JsonResult(babylonModelName);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(Single single, List<Single> singleFloors, List<SingleRooms> singleRooms)
        {

            // house.Status = "Available";

            single.Status = "Available";
            _context.Add(single);
            await _context.SaveChangesAsync();
            return View("Index", "Single");
        }
    }
}
