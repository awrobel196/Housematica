using Housematica.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class LicenseType
    {
        [Key]
        public int IdLicenseType { get; set; }

        [Required]
        public string LicenseName { get; set; }


        [Required]
        public int ProjectAmount { get; set; }

        [Required]
        public int UserAmount { get; set; }

        [Required]
        public int VariantAmount { get; set; }

        [Required]
        public bool SettingsEnabled { get; set; }
        
        public bool IsDemo { get; set; }


        public List<License> License { get; set; }



    }
}
