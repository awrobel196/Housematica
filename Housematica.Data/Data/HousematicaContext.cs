using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Housematica.Data.Data.CMS;
using Housematica.Data.Data.CMS.Statistics;
using Housematica.Data.Data.CMS.Features;
using System.Linq.Expressions;
using System.Linq;
using Housematica.Intranet.ViewModel;
using Newtonsoft.Json;

namespace Housematica.Data.Data
{
    public class HousematicaContext : DbContext
    {

        public HousematicaContext(DbContextOptions<HousematicaContext> options) : base(options)
        {

        }

        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<Projects> Projects { get; set; }

        public DbSet<ProjectsContact> ProjectsContacts { get; set; }

        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<ApartmentOption> ApartmentOption { get; set; }
        public DbSet<ApartmentVariants> ApartmentVariants { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Views> Views { get; set; }
        public DbSet<UViews> UViews { get; set; }

        public DbSet<License> License { get; set; }
        public DbSet<LicenseType> LicenseType { get; set; }
        public DbSet<ProjectsUser> ProjectsUser { get; set; }
        public DbSet<TotalConfiguration> TotalConfiguration { get; set; }
        public DbSet<ProjectsLicense> ProjectsLicense { get; set; }
        public DbSet<Notification> Notification { get; set; }

        
        public DbSet<CMS.Single> Single { get; set; }
        public DbSet<CMS.SingleFloor> SingleFloor { get; set; }
        public DbSet<CMS.SingleRooms> SingleRooms { get; set; }
        public DbSet<SavedConfiguration> SavedConfiguration { get; set; }


        public StatsViewModel Get<T>(Expression<Func<T, bool>> predicate)
   where T : class
        {







            var listFromDatabase = Set<T>().Where(predicate).ToList();
            List<StatsViewModel> targetlst = JsonConvert.DeserializeObject<List<StatsViewModel>>(JsonConvert.SerializeObject(listFromDatabase));

            var item = targetlst.Select(x => new StatsViewModel
            {
                January = targetlst.Sum(x => x.January),
                February = targetlst.Sum(x => x.February),
                March = targetlst.Sum(x => x.March),
                April = targetlst.Sum(x => x.April),
                May = targetlst.Sum(x => x.May),
                June = targetlst.Sum(x => x.June),
                July = targetlst.Sum(x => x.July),
                August = targetlst.Sum(x => x.August),
                September = targetlst.Sum(x => x.September),
                October = targetlst.Sum(x => x.October),
                November = targetlst.Sum(x => x.November),
                December = targetlst.Sum(x => x.December),
            }).FirstOrDefault();


            //item.January = targetlst.Sum(x => x.January);
            //item.February = targetlst.Sum(x => x.February);
            //item.March = targetlst.Sum(x => x.March);
            //item.April = targetlst.Sum(x => x.April);
            //item.May = targetlst.Sum(x => x.May);
            //item.June = targetlst.Sum(x => x.June);
            //item.July = targetlst.Sum(x => x.July);
            //item.August = targetlst.Sum(x => x.August);
            //item.September = targetlst.Sum(x => x.September);
            //item.October = targetlst.Sum(x => x.October);
            //item.November = targetlst.Sum(x => x.November);
            //item.December = targetlst.Sum(x => x.December);


            //if (typeof(UViews).IsAssignableFrom(typeof(T)))
            //{
            //    var list = listFromDatabase.Cast<UViews>().ToList();


            //    item.January = list.Sum(x => x.January);
            //    item.February = list.Sum(x => x.February);
            //    item.March = list.Sum(x => x.March);
            //    item.April = list.Sum(x => x.April);
            //    item.May = list.Sum(x => x.May);
            //    item.June = list.Sum(x => x.June);
            //    item.July = list.Sum(x => x.July);
            //    item.August = list.Sum(x => x.August);
            //    item.September = list.Sum(x => x.September);
            //    item.October = list.Sum(x => x.October);
            //    item.November = list.Sum(x => x.November);
            //    item.December = list.Sum(x => x.December);
            //}else if (typeof(Views).IsAssignableFrom(typeof(T)))
            //    {
            //    var list = listFromDatabase.Cast<Views>().ToList();
            //    item.January = list.Sum(x => x.January);
            //    item.February = list.Sum(x => x.February);
            //    item.March = list.Sum(x => x.March);
            //    item.April = list.Sum(x => x.April);
            //    item.May = list.Sum(x => x.May);
            //    item.June = list.Sum(x => x.June);
            //    item.July = list.Sum(x => x.July);
            //    item.August = list.Sum(x => x.August);
            //    item.September = list.Sum(x => x.September);
            //    item.October = list.Sum(x => x.October);
            //    item.November = list.Sum(x => x.November);
            //    item.December = list.Sum(x => x.December);
            //}
            //else
            //{
            //    var list = listFromDatabase.Cast<TotalConfiguration>().ToList();
            //    item.January = list.Sum(x => x.January);
            //    item.February = list.Sum(x => x.February);
            //    item.March = list.Sum(x => x.March);
            //    item.April = list.Sum(x => x.April);
            //    item.May = list.Sum(x => x.May);
            //    item.June = list.Sum(x => x.June);
            //    item.July = list.Sum(x => x.July);
            //    item.August = list.Sum(x => x.August);
            //    item.September = list.Sum(x => x.September);
            //    item.October = list.Sum(x => x.October);
            //    item.November = list.Sum(x => x.November);
            //    item.December = list.Sum(x => x.December);
            //}

            return item;
        }

        StatsViewModel Map(UViews b) => new StatsViewModel { January = b.January };


    }


}
