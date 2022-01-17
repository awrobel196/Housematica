using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housematica.Data.Data.CMS
{
    public class SavedConfiguration
    {
        [Key]
        public int Id { get; set; }
        public string SavedConfigurationKey { get; set; }

        //Like kitchen
        public string ConfigurationType { get; set; }

        //Like Id=12
        public string ConfigurationValue { get; set; }
    }
}
