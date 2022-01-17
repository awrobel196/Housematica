using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.ViewModel
{
    public class ProjectsViewModel
    {

        public Guid IdProject { get; set; }
        public string Adress { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectType { get; set; }
        public int Views { get; set; }
        public int UViews { get; set; }
        public int TotalConfiguration { get; set; }
        public bool IsActive { get; internal set; }
        public bool IsValidate { get; internal set; }
        public int ApartmentNumber { get; set; }
        public int HouseNumber { get; set; }
        public int SingleNumber { get; set; }
        public int ApartmentOptionsNumber { get; internal set; }
        public int HouseOptionsNumber { get; internal set; }
    }
}
