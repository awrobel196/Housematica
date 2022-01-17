using Housematica.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.NewWWW.ViewModels
{
    public class KartaViewModel
    {
        public string owner { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string contactPerson { get; set; }

        public string projectName { get; set; }
        public string apartmentName { get; set; }

        public string floor { get; set; }
        public string area { get; set; }
        public string balconArea { get; set; }

        public List<Rooms> rooms { get; set; }

    }
}
