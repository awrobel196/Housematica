using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Housematica.Data.Data;
using Housematica.Data.Data.CMS;
using Newtonsoft.Json;
using Housematica.WWW.DTO;
using Microsoft.AspNetCore.Http;

using Housematica.NewWWW.ViewModels;
using Housematica.NewWWW.Services;
using System.Threading;

namespace Housematica.NewWWW.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly HousematicaContext _context;

        public ProjectsController(HousematicaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> karta()
        {
            return View("Details", Guid.NewGuid());
        }

     
        public async Task<IActionResult> Details(string id)
        {

            var project = _context.Projects.Where(x => x.IdProject.ToString().Substring(0, 8) == id).Include(x => x.Apartment).ThenInclude(x => x.ApartmentVariants).FirstOrDefault();
            // var watch = System.Diagnostics.Stopwatch.StartNew();
            AddViewDto addViewDto = new AddViewDto(_context);
            AddUViewDto addUViewDto = new AddUViewDto(_context);
            AddClickDto addClickDto = new AddClickDto(_context);
            var a = Request.Cookies["housematicaView"];

            if (Request.Cookies["housematicaView"] is null)
            {
                string key = "housematicaView";
                string value = "thisisvalue";
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Append(key, value, cookieOptions);
                await addViewDto.AddNewView(project.IdProject);
                await addClickDto.AddNewClick(project.IdProject);
                await addUViewDto.AddNewView(project.IdProject);

            }
            else
            {
                await addViewDto.AddNewView(project.IdProject);
                await addClickDto.AddNewClick(project.IdProject);
            }
            
            return View(project);
        }

        public async Task<IActionResult> DetailsFrame(string id)
        {

            var project = _context.Projects.Where(x => x.IdProject.ToString().Substring(0, 8) == id).Include(x => x.Apartment).ThenInclude(x => x.ApartmentVariants).FirstOrDefault();
            // var watch = System.Diagnostics.Stopwatch.StartNew();
            AddViewDto addViewDto = new AddViewDto(_context);
            AddUViewDto addUViewDto = new AddUViewDto(_context);
            AddClickDto addClickDto = new AddClickDto(_context);
            var a = Request.Cookies["housematicaView"];

            if (Request.Cookies["housematicaView"] is null)
            {
                string key = "housematicaView";
                string value = "thisisvalue";
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Append(key, value, cookieOptions);
                await addViewDto.AddNewView(project.IdProject);
                await addClickDto.AddNewClick(project.IdProject);
                await addUViewDto.AddNewView(project.IdProject);

            }
            else
            {
                await addViewDto.AddNewView(project.IdProject);
                await addClickDto.AddNewClick(project.IdProject);
            }

            return View(project);
        }


        //Ładowanie za pomocą AJAX układów mieszkania
        public IActionResult loadUklad(int IdApartment)
        {
            var uklady = _context.ApartmentVariants.Where(x => x.IdApartment == IdApartment).Include(p => p.Rooms).ToList();

            var jsonRoomList = JsonConvert.SerializeObject(uklady, Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Content(jsonRoomList, "application/json");
        }



        //Ładowanie za pomocą AJAX kuchnii mieszkania
        public IActionResult loadKuchnia(int IdApartment)
        {
            var kuchnie = _context.ApartmentOption.Where(x => x.IdApartment == IdApartment && x.OptionType == "Kitchen").ToList();

            var jsonRoomList = JsonConvert.SerializeObject(kuchnie, Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Content(jsonRoomList, "application/json");
        }


        //Ładowanie za pomocą AJAX pokoii mieszkania
        public IActionResult loadPokoje(int IdApartment)
        {
            var kuchnie = _context.ApartmentOption.Where(x => x.IdApartment == IdApartment && x.OptionType == "Rooms").ToList();

            var jsonRoomList = JsonConvert.SerializeObject(kuchnie, Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Content(jsonRoomList, "application/json");
        }


        //Ładowanie za pomocą AJAX łazienki mieszkania
        public IActionResult loadLazienki(int IdApartment)
        {
            var kuchnie = _context.ApartmentOption.Where(x => x.IdApartment == IdApartment && x.OptionType == "Bathroom").ToList();

            var jsonRoomList = JsonConvert.SerializeObject(kuchnie, Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Content(jsonRoomList, "application/json");
        }


        //Ładowanie za pomocą AJAX łazienki mieszkania
        public IActionResult loadWykonczenia(int IdApartment)
        {
            var kuchnie = _context.ApartmentOption.Where(x => x.IdApartment == IdApartment && x.OptionType == "Door and window").ToList();

            var jsonRoomList = JsonConvert.SerializeObject(kuchnie, Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Content(jsonRoomList, "application/json");
        }


        public JsonResult loadConfiguration(string configKey)
        {
           
            List<ConfigurationViewModel> configuration = new List<ConfigurationViewModel>();
            configuration = _context.SavedConfiguration.Where(x => x.SavedConfigurationKey == configKey).Select(x => new ConfigurationViewModel
            {
                Name = x.ConfigurationType,
                Id = x.ConfigurationValue,
            }).ToList();

            var elo = JsonService<List<ConfigurationViewModel>>.convertToJson(configuration);
            return Json(elo);
        }


    public class ConfigurationViewModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public async Task<IActionResult> kartaMieszkania(KartaHelperViewModel karta)
    {

        ApartmentVariants list = _context.ApartmentVariants.Where(x => x.IdApartmentVariants == Convert.ToInt32(karta.idUklad)).Include(x => x.Rooms).Include(x => x.Apartment).ThenInclude(x => x.Projects).ThenInclude(x => x.ProjectsContact).FirstOrDefault();

        KartaViewModel kartaMieszkania = new KartaViewModel();
        kartaMieszkania.owner = list.Apartment.Projects.OwnerName;
        kartaMieszkania.phone = list.Apartment.Projects.ProjectsContact.OwnerPhone;
        kartaMieszkania.email = list.Apartment.Projects.ProjectsContact.OwnerEmail;
        kartaMieszkania.contactPerson = list.Apartment.Projects.ProjectsContact.ContactPerson;

        kartaMieszkania.projectName = list.Apartment.Projects.ProjectName;
        kartaMieszkania.apartmentName = list.Apartment.ApartmentName;

        kartaMieszkania.floor = list.Apartment.Floor.ToString();
        kartaMieszkania.area = list.ApartmentArea.ToString();
        kartaMieszkania.balconArea = list.BalconyArea.ToString();

        kartaMieszkania.rooms = list.Rooms.ToList();



        return View(kartaMieszkania);

    }
}

    
}
