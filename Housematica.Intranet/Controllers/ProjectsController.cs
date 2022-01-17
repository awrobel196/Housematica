using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Housematica.Data.Data;
using Housematica.Data.Data.CMS;
using Z.EntityFramework.Extensions;
using System.Xml.Schema;
using Newtonsoft.Json;

using AutoMapper;
using Housematica.Intranet.ViewModel;
using Housematica.Data.Data.CMS.Statistics;
using Microsoft.AspNetCore.Authorization;

namespace Housematica.Intranet.Controllers
{
    // [Authorize]
    public class ProjectsController : Controller
    {

        private readonly HousematicaContext _context;
        private readonly IMapper _mapper;
        public ActionResult EditGetItem(Guid id)
        {

            var project = _mapper.ProjectTo<ProjectEditViewModel>(_context.Projects.Where(x => x.IdProject == id)).ToList();
            //var prijects2 = _context.Projects.ProjectTo<ProjectEdit>();
            //var projects = _context.Projects.Where(p => p.IdProject == id).Include(p => p.ProjectsContact).Select(p => new ProjectEdit
            //{
            //    IdProject = p.IdProject,
            //    ProjectName = p.ProjectName,
            //    ProjectDescription = p.ProjectDescription,
            //    ContactPerson = p.ProjectsContact.ContactPerson,
            //    OwnerAdress = p.ProjectsContact.OwnerAdress,
            //    OwnerEmail = p.ProjectsContact.OwnerEmail,
            //    OwnerPhone = p.ProjectsContact.OwnerPhone
            //}).ToList();
            //if (projects == null)
            //{
            //    return NotFound();
            //}

            var list = JsonConvert.SerializeObject(project,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
            return Content(list, "application/json");

        }

        public ActionResult SetActive(Guid id)
        {
            var project = _context.Projects.Where(p => p.IdProject == id).FirstOrDefault();
            project.IsActive = true;
            _context.SaveChanges();

            return Json(true);
        }

        public ActionResult SetInactive(Guid id)
        {
            var project = _context.Projects.Where(p => p.IdProject == id).FirstOrDefault();
            project.IsActive = false;
            _context.SaveChanges();

            return Json(true);
        }

        public ActionResult EditItem(Guid IdProject, string OwnerAdress, string OwnerEmail, string OwnerPhone, string ContactPerson, string ProjectDescription, string ProjectName)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;

            Projects projects = new Projects();
            ProjectsContact contact = new ProjectsContact();

            projects = _context.Projects.Where(x => x.IdProject == IdProject).FirstOrDefault();
            contact = _context.ProjectsContacts.Where(x => x.IdProjects == IdProject).FirstOrDefault();

            projects.IdProject = IdProject;
            projects.ProjectDescription = ProjectDescription;
            projects.ProjectName = ProjectName;

            contact.IdProjects = IdProject;
            contact.OwnerAdress = OwnerAdress;
            contact.OwnerEmail = OwnerEmail;
            contact.OwnerPhone = OwnerPhone;
            contact.ContactPerson = ContactPerson;


            _context.Update(projects);
            _context.Update(contact);
            _context.SaveChanges();
            return Json(new { success = true });

        }


        public ProjectsController(HousematicaContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ActionResult GetData(Guid id)
        {
            var models = _context.Apartment.Include(p => p.Projects).Where(p => p.IdProjects == id).ToList();




            var list = JsonConvert.SerializeObject(models,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });



            return Content(list, "application/json");
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var elo = User.Identities.ToList();
            
            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            //var housematicaContext = _context.ProjectsUser.Where(x => x.IdUser == new Guid(claims)).Select(x => x.Projects).
            //    Where(p => p.IsDelete == false).Include(x => x.TotalConfiguration);



            //var housematicaContext = _context.ProjectsUser.Where(x => x.IdUser == new Guid(claims)).Select(x => x.Projects).
            //  Where(p => p.IsDelete == false).Include(p => p.ProjectType).Include(p => p.ProjectsContact).Include(p => p.Views).Include(p => p.UViews).
            //  Include(p => p.TotalConfiguration).Include(p => p.Apartment).ThenInclude(p => p.ApartmentVariants).Include(p => p.Apartment).ThenInclude(p => p.ApartmentOption);

            var housematicaContext = _context.Projects.Where(x => x.ProjectsLicense.Any(x => x.IdLicense == new Guid(license))).Where(p => p.IsDelete == false).Select(x => new ProjectsViewModel
            {
                IdProject = x.IdProject,
               Adress = $"{x.ProjectPostcode} {x.ProjectCity}, ul.{x.ProjectAdress1} {x.ProjectAdress2}",
                ProjectDescription = x.ProjectDescription,
                ProjectName = x.ProjectName,
                ProjectType = x.ProjectType.ConfiguratorType,
                IsActive = x.IsActive,
                IsValidate = x.IsValidate,
                TotalConfiguration = x.TotalConfiguration.January + x.TotalConfiguration.February + x.TotalConfiguration.March + x.TotalConfiguration.April + x.TotalConfiguration.May + x.TotalConfiguration.June + x.TotalConfiguration.July + x.TotalConfiguration.August + x.TotalConfiguration.September + x.TotalConfiguration.October + x.TotalConfiguration.November + x.TotalConfiguration.December,
                Views = x.Views.January + x.Views.February + x.Views.March + x.Views.April + x.Views.May + x.Views.June + x.Views.July + x.Views.August + x.Views.September + x.Views.October + x.Views.November + x.Views.December,
                UViews = x.UViews.January + x.UViews.February + x.UViews.March + x.UViews.April + x.UViews.May + x.UViews.June + x.UViews.July + x.UViews.August + x.UViews.September + x.UViews.October + x.UViews.November + x.UViews.December,
               ApartmentNumber = x.Apartment.Count(),
               HouseNumber = x.House.Count(),
               HouseOptionsNumber = x.House.Select(x=>x.HouseVariants.Count()).FirstOrDefault() * x.House.Select(x => x.HouseVariants.Count()).FirstOrDefault(),
                ApartmentOptionsNumber = x.Apartment.Select(x => x.ApartmentVariants.Count()).FirstOrDefault() * x.Apartment.Select(x => x.ApartmentOption.Count()).FirstOrDefault(),
                SingleNumber = x.Single.Count()

            }).ToList();


            //var housematicaContext = _context.Projects.Where(p => p.ProjectsUser.Any(x => x.IdUser == new Guid(claims))).
            //   Where(p => p.IsDelete == false).Include(p => p.ProjectType).Include(p => p.ProjectsContact).Include(p => p.Views).
            //   Include(p => p.UViews).Include(p => p.TotalConfiguration).Include(p => p.Apartment).
            //   ThenInclude(p => p.ApartmentVariants).Include(p => p.Apartment).ThenInclude(p => p.ApartmentOption).ToListAsync();
            watch.Stop();
            var timer = watch.ElapsedMilliseconds;
            return View(housematicaContext);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            ViewBag.Team = _context.User.Where(x => x.IdLicense == new Guid(license)).ToList();
            var projects = await _context.Projects
                .Include(p => p.ProjectType).Include(p => p.ProjectsContact).Include(p => p.Views).Include(p => p.UViews).Include(p => p.TotalConfiguration).Include(p => p.Apartment).ThenInclude(p => p.ApartmentVariants).Include(p => p.Apartment).ThenInclude(p => p.ApartmentOption).Include(x => x.Single).ThenInclude(x=>x.SingleFloor).ThenInclude(x=>x.SingleRooms).Include(x=>x.ProjectType)
                .FirstOrDefaultAsync(m => m.IdProject == id);
            if (projects == null)
            {
                return NotFound();
            }

            return View(projects);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewBag.IdProjectType = new SelectList(_context.ProjectType, "IdProjectType", "Name");

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Projects projects, ProjectsContact projectsContact)
        {
            var claims = User.Identities.FirstOrDefault()?.Claims.FirstOrDefault()?.Value;
            var license = User.Identities.FirstOrDefault()?.Claims.LastOrDefault()?.Value;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            Views views = new Views();
            UViews uviews = new UViews();
            TotalConfiguration totalConfiguration = new TotalConfiguration();

            Random randomId = new Random();
            projects.IsActive = true;
            projects.IsDelete = false;
            _context.Add(projects);

            _context.SaveChanges();



            views.IdProjects = projects.IdProject;
            views.January = 0;
            views.February = 0;
            views.March = 0;
            views.April = 0;
            views.May = 0;
            views.June = 0;
            views.July = 0;
            views.August = 0;
            views.September = 0;
            views.October = 0;
            views.November = 0;
            views.December = 0;

            uviews.IdProjects = projects.IdProject;
            uviews.January = 0;
            uviews.February = 0;
            uviews.March = 0;
            uviews.April = 0;
            uviews.May = 0;
            uviews.June = 0;
            uviews.July = 0;
            uviews.August = 0;
            uviews.September = 0;
            uviews.October = 0;
            uviews.November = 0;
            uviews.December = 0;

            totalConfiguration.IdProjects = projects.IdProject;
            totalConfiguration.January = 0;
            totalConfiguration.February = 0;
            totalConfiguration.March = 0;
            totalConfiguration.April = 0;
            totalConfiguration.May = 0;
            totalConfiguration.June = 0;
            totalConfiguration.July = 0;
            totalConfiguration.August = 0;
            totalConfiguration.September = 0;
            totalConfiguration.October = 0;
            totalConfiguration.November = 0;
            totalConfiguration.December = 0;

            projectsContact.IdProjects = projects.IdProject;
            _context.Add(new ProjectsLicense
            {
                IdProject = projects.IdProject,
                IdLicense = new Guid(license),
            });
            _context.Add(projectsContact);
            _context.Add(views);
            _context.Add(uviews);
            _context.Add(totalConfiguration);
            _context.SaveChanges();


            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;

            return RedirectToAction(nameof(Index));



            //ViewData["IdProjectType"] = new SelectList(_context.ProjectType, "IdProjectType", "Description", projects.IdProjectType);
            //return View(projects);
        }


        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.Include(x => x.ProjectsContact).FirstOrDefaultAsync(p => p.IdProject == id);
            if (projects == null)
            {
                return NotFound();
            }
            ViewData["IdProjectType"] = new SelectList(_context.ProjectType, "IdProjectType", "Description", projects.IdProjectType);
            return View(projects);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Projects projects, ProjectsContact projectsContact)
        {

            projects.ProjectsContact = projectsContact;
            _context.Update(projects);

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Projects", new { id = projects.IdProject });
        }


        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var project = _context.Projects.Where(p => p.IdProject == id).FirstOrDefault();
            project.IsDelete = true;
            await _context.SaveChangesAsync();
            return Ok();
        }



        private bool ProjectsExists(Guid id)
        {
            return _context.Projects.Any(e => e.IdProject == id);
        }
    }


}
