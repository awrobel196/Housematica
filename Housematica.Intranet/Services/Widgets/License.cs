using Housematica.Data.Data;
using Housematica.Intranet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Housematica.Intranet.Services
{
    public class License : ILicense
    {
        private readonly HousematicaContext _context;
        private List<Data.Data.CMS.License> license;
        public License(HousematicaContext context)
        {
            _context = context;
            license = _context.License.Include(x=>x.LicenseType).Include(x=>x.ProjectsLicense).ThenInclude(x=>x.Projects).ThenInclude(x=>x.Apartment).ToList();
        }

        public string licenseExpired(Guid License)
        {
            var licenseExpired = license.Where(x => x.IdLicense == License).Select(x => x.Expire).FirstOrDefault();
            return (licenseExpired.ToString("dd.MM.yyyy"));
        }

        public double percentageLicenseUsing(Guid License)
        {
            var totalProjectLicense = license.Where(x => x.IdLicense == License).Select(x => x.LicenseType.ProjectAmount)
                .FirstOrDefault();
            var userProjectLicenseUsed = license.Where(x => x.IdLicense == License).Select(x => x.ProjectsLicense.Count()).FirstOrDefault();
            return (Math.Round(((double)userProjectLicenseUsed / (double)totalProjectLicense) * 100, 0));
        }

        public double projectAvailable(Guid License)
        {
            var totalProjectLicense = license.Where(x => x.IdLicense == License).Select(x => x.LicenseType.ProjectAmount).FirstOrDefault();
            var userProjectLicenseUsed = license.Where(x => x.IdLicense == License).Select(x => x.ProjectsLicense.Count()).FirstOrDefault();
            return (totalProjectLicense - userProjectLicenseUsed);
        }

        public double userAvailable(Guid License)
        {
            var maxUser = license.Where(x => x.IdLicense == License).Select(x => x.LicenseType.UserAmount).FirstOrDefault();
            var currentUser = license.Where(x => x.IdLicense == License).Select(x => x.User).Count();
            return (maxUser - currentUser);
        }

        public double variantsAvailable(Guid License)
        {
            var maxVariants = license.Where(x => x.IdLicense == License).Select(x => x.LicenseType.VariantAmount).FirstOrDefault();
            var currentVariants = license.Where(x => x.IdLicense == License).Select(x => x.ProjectsLicense.Select(x => x.Projects.Apartment.Select(x => x.ApartmentVariants)).Count()).FirstOrDefault();
            return maxVariants - currentVariants;
        }
    }
}




//using Housematica.Data.Data;
//using Housematica.Intranet.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Housematica.Intranet.Services
//{
//    public class License : ILicense
//    {
//        private readonly HousematicaContext _context;
//        public License(HousematicaContext context)
//        {
//            _context = context;
//        }

//        public string licenseExpired(Guid License)
//        {
//            var licenseExpired = _context.License.Where(x => x.IdLicense == License).Select(x => x.Expire).FirstOrDefault();
//            return (licenseExpired.ToString("dd.MM.yyyy"));
//        }

//        public double percentageLicenseUsing(Guid License)
//        {
//            var totalProjectLicense = _context.License.Where(x => x.IdLicense == License).Select(x => x.LicenseType.ProjectAmount)
//                .FirstOrDefault();

//            var userProjectLicenseUsed = _context.License.Where(x => x.IdLicense == License).Select(x => x.ProjectsLicense.Count()).FirstOrDefault();

//            return (Math.Round(((double)userProjectLicenseUsed / (double)totalProjectLicense) * 100, 0));
//        }

//        public double projectAvailable(Guid License)
//        {
//            var totalProjectLicense = _context.License.Where(x => x.IdLicense == License).Select(x => x.LicenseType.ProjectAmount).FirstOrDefault();

//            var userProjectLicenseUsed = _context.License.Where(x => x.IdLicense == License).Select(x => x.ProjectsLicense.Count()).FirstOrDefault();

//            return (totalProjectLicense - userProjectLicenseUsed);
//        }

//        public double userAvailable(Guid License)
//        {

//            var maxUser = _context.License.Where(x => x.IdLicense == License).Select(x => x.LicenseType.UserAmount).FirstOrDefault();

//            var currentUser = _context.User.Where(x => x.IdLicense == License).Count();


//            return (maxUser - currentUser);
//        }

//        public double variantsAvailable(Guid License)
//        {
//            var maxVariants = _context.License.Where(x => x.IdLicense == License).Select(x => x.LicenseType.VariantAmount).FirstOrDefault();



//            var currentVariants = _context.License.Where(x => x.IdLicense == License).Select(x => x.ProjectsLicense.Select(x => x.Projects.Apartment.Select(x => x.ApartmentVariants)).Count()).FirstOrDefault();

//            return maxVariants - currentVariants;

//        }
//    }
//}
