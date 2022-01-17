using FluentFTP;
using Housematica.Data.Data;
using Housematica.Data.Data.CMS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Housematica.Intranet.Controllers
{
    public class HouseController : Controller
    {
        private HousematicaContext _context;

        public HouseController(HousematicaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            ViewBag.IdProjects = new SelectList(_context.Projects.Where(x => x.ProjectsLicense.Any(x => x.IdLicense == new Guid(license))).Where(x => x.IsDelete == false).Where(x => x.ProjectType.ConfiguratorType == "D"), "IdProject", "ProjectName");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UploadFiles(IList<IFormFile> files, string projectName, string apartmentName, string modelType)
        {
            string secondPath = "/cdn/" + projectName + "/" + apartmentName + "/" + modelType;
            // check if a file exists



            // create an FTP client
            FtpClient client = new FtpClient("162.55.43.54");

            // specify the login credentials, unless you want to use the "anonymous" user account
            client.Credentials = new NetworkCredential("ftp@cdn.housematica.pl", "3Ac2uq94#");

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
                    client.Upload(source.OpenReadStream(), $"{secondPath}/source.jpg");
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


        public async Task<IActionResult> Create(House house, List<HouseVariants> houseVariants, List<HouseOption> houseOption, List<HouseRooms> houseRooms)
        {
            List<HouseOption> houseList = new List<HouseOption>();
            houseList = house.HouseOption.Where(x => !string.IsNullOrWhiteSpace(x.OptionName)).ToList();
            house.HouseOption.Clear();
            house.HouseOption = houseList;
           // house.Status = "Available";

            _context.Add(house);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["IdProjects"] = new SelectList(_context.Projects, "IdProject", "OwnerName", house.IdProjects);
            return View(house);
        }
    }
}
