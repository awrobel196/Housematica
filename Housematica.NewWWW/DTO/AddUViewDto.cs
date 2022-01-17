using Housematica.Data.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.WWW.DTO
{
    public class AddUViewDto
    {
        private readonly HousematicaContext _context;
        public AddUViewDto(HousematicaContext context)
        {
            _context = context;
        }


        public async Task AddNewView(Guid id)
        {
            string monthName = DateTime.Now.ToString("MMMM", new CultureInfo("en-GB"));

            var views = 0;

            switch (monthName)
            {
                case "January":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.January).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.January = views);
                    break;
                case "February":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.February).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.February = views);
                    break;
                case "March":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.March).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.March = views);
                    break;
                case "April":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.April).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.April = views);
                    break;
                case "May":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.May).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.May = views);
                    break;
                case "June":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.June).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.June = views);
                    break;
                case "July":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.July).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.July = views);
                    break;
                case "August":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.August).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.August = views);
                    break;
                case "September":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.September).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.September = views);
                    break;
                case "October":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.October).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.October = views);
                    break;
                case "November":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.November).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.November = views);
                    break;
                case "December":
                    views = _context.UViews.Where(x => x.IdProjects == id).Select(x => x.December).FirstOrDefault();
                    views += 1;
                    _context.UViews.Where(x => x.IdProjects == id).ToList().ForEach(x => x.December = views);
                    break;

            }

           await _context.SaveChangesAsync();
        }
     
    }
}
