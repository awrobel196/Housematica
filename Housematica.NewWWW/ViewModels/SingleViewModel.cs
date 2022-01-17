using Housematica.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.NewWWW.ViewModels
{
    public class SingleViewModel
    {
        public string Name { get; set; }
        public string NumberOfFloor { get; set; }
        public string Area { get; set; }
        public string Image { get; set; }
        public string AreaBuild { get; set; }
        public string Price { get; set; }

        public string ProjectName { get; set; }
        public string ProjectOwnerName { get; set; }
        public string ProjectAdress { get; set; }
        public string Project { get; set; }
        public string ProjectPostcode { get; set; }
        public string ProjectCity{ get; set; }

        public List<SingleFloor> SingleFloor { get; set; }
    }
}
