using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Housematica.Data.Data;

using Housematica.Data.Data.CMS;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Housematica.Data.Model;
using FluentFTP;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Housematica.Intranet.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly HousematicaContext _context;
        private IHostingEnvironment hostingEnv;
        private IConfiguration _configuration;

        public ApartmentController(HousematicaContext context, IHostingEnvironment env, IConfiguration configuration)
        {
            this.hostingEnv = env;
            _context = context;
            _configuration = configuration;
        }

        // GET: Apartment
        public async Task<IActionResult> Index()
        {
            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            var apartments = _context.Apartment.Where(x => x.Projects.ProjectsLicense.Any(x => x.IdLicense == new Guid(license))).Include(x => x.Projects).Include(x=>x.ApartmentVariants).ToList();
            return View(apartments);
        }

        public async Task<IActionResult> List(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var projects = await _context.Projects
                .Include(p => p.ProjectType).Include(p => p.ProjectsContact).Include(p => p.Views).Include(p => p.UViews).Include(p => p.TotalConfiguration).Include(p => p.Apartment).ThenInclude(p => p.ApartmentVariants).Include(p => p.Apartment).ThenInclude(p => p.ApartmentOption)
                .FirstOrDefaultAsync(m => m.IdProject == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }


        // GET: Apartment/Create
        public IActionResult Create()
        {
            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            ViewBag.IdProjects = new SelectList(_context.Projects.Where(x=>x.ProjectsLicense.Any(x=>x.IdLicense==new Guid(license))).Where(x=>x.IsDelete==false).Where(x=>x.ProjectType.ConfiguratorType=="A"), "IdProject", "ProjectName");
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
            if (!client.DirectoryExists($"{secondPath}/")) {
                client.CreateDirectory(secondPath);
            }

           

            
            // upload a file
            
            if(files.Count() <2)
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

            var babylonModelName = files.Select(x=>x.FileName).Where(x=>x.EndsWith("babylon")).FirstOrDefault().ToString();
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

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }
      
        private string GetPathAndFilename(string filename, string projectName, string apartmentFileName, string apartmentModelType)
        {
            string root = this.hostingEnv.WebRootPath+"\\"+ projectName;
            string secondPath = this.hostingEnv.WebRootPath + "\\" + projectName + "\\" + apartmentFileName;
            string thirdPath = this.hostingEnv.WebRootPath + "\\" + projectName + "\\" + apartmentFileName + "\\" + apartmentModelType;
            
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
                Directory.CreateDirectory(secondPath);
                Directory.CreateDirectory(thirdPath);

            }
            else if (!Directory.Exists(secondPath))
            {
                Directory.CreateDirectory(secondPath);
                Directory.CreateDirectory(thirdPath);
            }else if (!Directory.Exists(thirdPath))
            {
                Directory.CreateDirectory(thirdPath);
            }
           
             return thirdPath + "\\" + filename;
        }

      

        // POST: Apartment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(Apartment apartment, List<ApartmentVariants> apartmentVariants, List<ApartmentOption> apartmentOption, List<Rooms> rooms)
        {
            List<ApartmentOption> apartmentList = new List<ApartmentOption>();
            apartmentList = apartment.ApartmentOption.Where(x => !string.IsNullOrWhiteSpace(x.OptionName)).ToList();
            apartment.ApartmentOption.Clear();
            apartment.ApartmentOption = apartmentList;
            apartment.Status = "Available";

            _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
            ViewData["IdProjects"] = new SelectList(_context.Projects, "IdProject", "OwnerName", apartment.IdProjects);
            return View(apartment);
        }


  
        // POST: Apartment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartment.FindAsync(id);
            _context.Apartment.Remove(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartment.Any(e => e.IdApartment == id);
        }
    }
}
